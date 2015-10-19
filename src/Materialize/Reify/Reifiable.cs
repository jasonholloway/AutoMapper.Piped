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

        
    internal interface IReifiable<TMap> : IQueryProvider
    {
        IQueryable<TMap> BaseReifyQuery { get; }
    }
    


    class Reifiable<TSource, TMap> : IReifiable<TMap>
    {
        static PropertyInfo _baseReifyQueryProp = typeof(Reifiable<TSource, TMap>)
                                                        .GetProperty(nameof(BaseReifyQuery));


        ISourceRegimeProvider _regimeSource;
        ParserFactory _parserFac;
        MaterializeOptions _options;
        

        public IQueryable<TSource> SourceQuery { get; private set; }
        public IQueryable<TMap> BaseReifyQuery { get; private set; }


        public Reifiable(
            IQueryable<TSource> sourceQuery, 
            ISourceRegimeProvider regimeSource,
            ParserFactory parserFac,
            MaterializeOptions options)
        {
            SourceQuery = sourceQuery;

            BaseReifyQuery = CreateQuery<TMap>(
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



        
        static IQueryable PackageAsQueryable(Type tElem, IEnumerable items) 
        {            
            var tCont = typeof(EnumerableQuery<>).MakeGenericType(tElem);
            return (IQueryable)Activator.CreateInstance(tCont, items);
        }





        abstract class Fetcher
        {
            public abstract object FetchFrom(IQueryable qySource);

            public static Fetcher Create(Parser.Result parseResult, ISnooper snooper = null) 
            {
                var tFetcher = typeof(Fetcher<,>).MakeGenericType(
                                                        typeof(TSource),
                                                        typeof(TMap),
                                                        parseResult.UsedStrategy.FetchType,
                                                        parseResult.UsedStrategy.DestType);

                return (Fetcher)Activator.CreateInstance(
                                                    tFetcher,
                                                    parseResult.Modifier,
                                                    snooper); 
            }
        }
        
        class Fetcher<TFetch, TDest> : Fetcher
        {
            IModifier _mod;
            ISnooper _snooper;

            public Fetcher(IModifier mod, ISnooper snooper) {
                _mod = mod;
                _snooper = snooper;
            }

            public override object FetchFrom(IQueryable qySource) 
            {
                //modifier stack rewrites the SourceQuery expression
                var exFetch = _mod.FetchMod(qySource.Expression);
                
                //fetch from source; transform fetched via modifiers                                    
                if(typeof(IQueryable).IsAssignableFrom(exFetch.Type)) {
                    var qyFetch = qySource.Provider.CreateQuery(exFetch);

                    _snooper?.OnFetch(qyFetch);
                    _snooper?.OnFetch(exFetch);

                    var fetched = (TFetch)(object)(IEnumerable)qyFetch;
                    _snooper?.OnFetched((IEnumerable)fetched);


                    var exTransformParam = Expression.Parameter(typeof(IEnumerable<>)
                                                                    .MakeGenericType(qyFetch.ElementType),
                                                                    "fetched");

                    var exTransformBody = _mod.TransformMod(exTransformParam);
                    _snooper?.OnTransform(exTransformBody);


                    var exFnTransform = Expression.Lambda<Func<TFetch, TDest>>(
                                                    exTransformBody,
                                                    exTransformParam);

                    var fnTransform = exFnTransform.Compile();

                    var transformed = fnTransform(fetched);
                                        
                    _snooper?.OnTransformed(transformed is IEnumerable
                                                ? (IEnumerable)transformed
                                                : new[] { transformed });

                    return transformed;
                }
                else {
                    throw new NotImplementedException();

                    //OnQueryToServer(exFetch);

                    //var fetched = SourceQuery.Provider.Execute(exFetch);
                    //OnFetched(new[] { fetched });

                    //var transformed = (TResult)parsed.Modifier.Transform(fetched);
                    //OnTransformed(new[] { transformed });

                    //return transformed;
                }
            }



            void OnQueryToServer(IQueryable query) {
                _snooper?.OnFetch(query);
            }

            void OnQueryToServer(Expression exQuery) {
                _snooper?.OnFetch(exQuery);
            }

            void OnFetched(IEnumerable elems) {
                _snooper?.OnFetched(elems);
            }


        }




        public TResult Execute<TResult>(Expression exClientQuery) 
        {
            OnQueryFromClient(exClientQuery);
            
            var reifyContext = new ReifyContext(
                                        _options.MappingEngine,
                                        _options.SourceRegime ?? _regimeSource.GetRegime(SourceQuery),
                                        typeof(TMap),
                                        (bool)_options.AllowClientSideFiltering);
            

            var parser = _parserFac.Create(
                                        BaseReifyQuery.Expression, 
                                        typeof(IQueryable<TSource>), 
                                        reifyContext);
                        
            var parsed = parser.Parse(exClientQuery);
            
            OnStrategized(parsed.UsedStrategy);


            var fetcher = Fetcher.Create(parsed, _options.Snooper);

            return (TResult)(object)fetcher.FetchFrom(SourceQuery);
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

        void OnTransformed(IEnumerable elems) {
            _options.Snooper?.OnTransformed(elems);
        }

        #endregion


    }

}
