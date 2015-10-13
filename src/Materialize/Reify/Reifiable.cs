using Materialize.Reify.Parsing;
using Materialize.SourceRegimes;
using Materialize.Types;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace Materialize.Reify
{
    //Reifiables are mostly QueryProviders, serving ReifyQueries
    //As such, they orchestrate query-parsing, fetching and transformation, via a stack of modifiers.

        
    internal interface IReifiable<TDest> : IQueryProvider
    {
        IQueryable<TDest> BaseReifyQuery { get; }
    }
    


    class Reifiable<TSource, TDest> : IReifiable<TDest>
    {
        static PropertyInfo _baseReifyQueryProp = typeof(Reifiable<TSource, TDest>)
                                                        .GetProperty("BaseReifyQuery");


        ISourceRegimeProvider _regimeSource;
        ParserFactory _parserFac;
        MaterializeOptions _options;
        

        public IQueryable<TSource> SourceQuery { get; private set; }
        public IQueryable<TDest> BaseReifyQuery { get; private set; }


        public Reifiable(
            IQueryable<TSource> sourceQuery, 
            ISourceRegimeProvider regimeSource,
            ParserFactory parserFac,
            MaterializeOptions options)
        {
            SourceQuery = sourceQuery;

            BaseReifyQuery = CreateQuery<TDest>(
                                    Expression.MakeMemberAccess(
                                                Expression.Constant(this), 
                                                _baseReifyQueryProp)
                                    );

            _regimeSource = regimeSource;
            _parserFac = parserFac;
            _options = options;
        }
        


        public IQueryable<TElement> CreateQuery<TElement>(Expression expression) {
            return new ReifyQuery<TElement>(this, expression);
        }


        public IQueryable CreateQuery(Expression expression) {
            //Just delegate via refl to typed method...
            throw new NotImplementedException();
        }



        public TResult Execute<TResult>(Expression exClientQuery) 
        {
            OnQueryFromClient(exClientQuery);
            
            var reifyContext = new ReifyContext(
                                        new TypeVector(typeof(IQueryable<TSource>), typeof(IQueryable<TDest>)),
                                        _options.MappingEngine,
                                        _options.SourceRegime ?? _regimeSource.GetRegime(SourceQuery),
                                        (bool)_options.AllowClientSideFiltering);
            

            var parser = _parserFac.Create(BaseReifyQuery.Expression, reifyContext);
                        
            var parsed = parser.Parse(exClientQuery);


            OnStrategized(parsed.UsedStrategy);
                                             

            //modifier stack rewrites the SourceQuery expression
            var exQuery = parsed.Modifier.Rewrite(SourceQuery.Expression);
            

            //fetch from source; transform fetched via modifiers                                    
            if(typeof(IQueryable).IsAssignableFrom(exQuery.Type)) {
                var query = SourceQuery.Provider.CreateQuery(exQuery);
                OnQueryToServer(query);

                var enFetched = (IEnumerable)query;

                OnFetched(enFetched);

                var transformed = parsed.Modifier.Transform(enFetched);
                
                OnTransformed(transformed is IEnumerable
                                    ? (IEnumerable)transformed
                                    : new[] { transformed });

                return (TResult)transformed;
            }
            else {
                //no simple way to implement QueryToServer hook
                //when expression is fed directly to Execute by unary method

                var fetched = SourceQuery.Provider.Execute(exQuery);
                OnFetched(new[] { fetched });

                var transformed = (TResult)parsed.Modifier.Transform(fetched);
                OnTransformed(new[] { transformed });

                return transformed;
            }
        }


        public object Execute(Expression expression) {
            //Just delegate via refl to typed method...
            throw new NotImplementedException();
        }




        #region Snooper stuff
        
        void OnQueryFromClient(Expression exQuery) {
            _options.Snooper?.OnQueryFromClient(exQuery);
        }

        void OnStrategized(IReifyStrategy strategy) {
            _options.Snooper?.OnStrategized(strategy);
        }

        void OnQueryToServer(IQueryable query) {
            _options.Snooper?.OnQueryToServer(query);
        }

        void OnFetched(IEnumerable elems) {
            _options.Snooper?.OnFetched(elems);
        }

        void OnTransformed(IEnumerable elems) {
            _options.Snooper?.OnTransformed(elems);
        }

        #endregion


    }

}
