using Materialize.Reify.Mapping;
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


    internal interface IReifiable : IQueryProvider
    {
        event EventHandler<Expression> QueryFromClient;
        event EventHandler<IQueryable> QueryToServer;
        event EventHandler<IEnumerable> Fetched;
        event EventHandler<IEnumerable> Transformed;
    }

    internal interface IReifiable<TDest> : IReifiable
    {
        IQueryable<TDest> BaseReifyQuery { get; }
    }



    abstract class Reifiable : IReifiable
    {
        public abstract IQueryable CreateQuery(Expression expression);
        public abstract IQueryable<TElement> CreateQuery<TElement>(Expression expression);
        public abstract object Execute(Expression expression);
        public abstract TResult Execute<TResult>(Expression expression);

        public event EventHandler<Expression> QueryFromClient;
        public event EventHandler<IQueryable> QueryToServer;
        public event EventHandler<IEnumerable> Fetched;
        public event EventHandler<IEnumerable> Transformed;


        protected void OnQueryFromClient(Expression exQuery) {
            if(QueryFromClient != null) {
                QueryFromClient(this, exQuery);
            }
        }

        protected void OnQueryToServer(IQueryable query) {
            if(QueryToServer != null) {
                QueryToServer(this, query);
            }
        }

        protected void OnFetched(IEnumerable elems) {
            if(Fetched != null) {
                Fetched(this, elems);
            }
        }

        protected void OnTransformed(IEnumerable elems) {
            if(Transformed != null) {
                Transformed(this, elems);
            }
        }        
    }
    


    class Reifiable<TSource, TDest> 
        : Reifiable, IReifiable<TDest>
    {
        static PropertyInfo _baseReifyQueryProp = typeof(Reifiable<TSource, TDest>)
                                                        .GetProperty("BaseReifyQuery");


        ISourceRegimeDetector _regimeDetector;
        ParserFactory _parserFac;
        

        public IQueryable<TSource> SourceQuery { get; private set; }
        public IQueryable<TDest> BaseReifyQuery { get; private set; }


        public Reifiable(
            IQueryable<TSource> sourceQuery, 
            ISourceRegimeDetector regimeDetector,
            ParserFactory parserFac)
        {
            SourceQuery = sourceQuery;

            BaseReifyQuery = CreateQuery<TDest>(
                                    Expression.MakeMemberAccess(
                                                Expression.Constant(this), 
                                                _baseReifyQueryProp)
                                    );

            _regimeDetector = regimeDetector;
            _parserFac = parserFac;
        }
        


        public override IQueryable<TElement> CreateQuery<TElement>(Expression expression) {
            return new ReifyQuery<TElement>(this, expression);
        }


        public override IQueryable CreateQuery(Expression expression) {
            //Just delegate via refl to typed method...
            throw new NotImplementedException();
        }



        public override TResult Execute<TResult>(Expression exClientQuery) 
        {
            OnQueryFromClient(exClientQuery);

            var mapContext = new MapContext(
                                    _regimeDetector.DetectRegime(SourceQuery.Provider),
                                    new TypeVector(typeof(IQueryable<TSource>), typeof(IQueryable<TDest>))
                                    );

            var parser = _parserFac.Create(BaseReifyQuery.Expression, mapContext);
            
            var modifierStack = parser.Parse(exClientQuery);
                                                            

            //modifier stack rewrites the SourceQuery expression
            var exQuery = modifierStack.Rewrite(SourceQuery.Expression);
            

            //fetch from source; transform fetched via modifiers                                    
            if(typeof(IQueryable).IsAssignableFrom(exQuery.Type)) {
                var query = SourceQuery.Provider.CreateQuery(exQuery);
                OnQueryToServer(query);

                var enFetched = (IEnumerable)query;

                OnFetched(enFetched);

                var transformed = modifierStack.Transform(enFetched);
                
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

                var transformed = (TResult)modifierStack.Transform(fetched);
                OnTransformed(new[] { transformed });

                return transformed;
            }
        }


        public override object Execute(Expression expression) {
            //Just delegate via refl to typed method...
            throw new NotImplementedException();
        }


    }

}
