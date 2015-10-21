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
        ISnooper _snoop;
        

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
            _snoop = options.Snooper;
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
            ISnooper _snoop;

            public Fetcher(IModifier mod, ISnooper snooper) {
                _mod = mod;
                _snoop = snooper;
            }

            public override object FetchFrom(IQueryable qySource) 
            {
                var exFetch = _mod.ServerFilter(qySource.Expression);
                exFetch = _mod.ServerProject(exFetch);

                //var exFetch = _mod.FetchMod(qySource.Expression);                
                _snoop?.OnFetch(exFetch);
                                
                var fetched = qySource.Provider.Execute<TFetch>(exFetch);
                _snoop?.OnFetched(fetched);


                var exParam = Expression.Parameter(typeof(TFetch), "fetched");

                //var exBody = _mod.TransformMod(exParam);
                var exBody = _mod.ClientTransform(exParam);
                _snoop?.OnTransform(exBody);

                var exFnTransform = Expression.Lambda<Func<TFetch, TDest>>(exBody, exParam);

                var fnTransform = exFnTransform.Compile();

                var transformed = fnTransform(fetched);
                _snoop?.OnTransformed(transformed);

                return transformed;                
            }
        }




        //modifier stack rewrites the SourceQuery expression
        //then compiles and executes transformation
        public TResult Execute<TResult>(Expression exQuery) 
        {
            _snoop?.OnQuery(exQuery);
            
            var reifyContext = new ReifyContext(
                                        _options.MappingEngine,
                                        _options.SourceRegime ?? _regimeSource.GetRegime(SourceQuery),
                                        typeof(TMap),
                                        (bool)_options.AllowClientSideFiltering);
            

            var parser = _parserFac.Create(
                                        BaseReifyQuery.Expression, 
                                        typeof(IQueryable<TSource>), 
                                        reifyContext);
                        
            var parsed = parser.Parse(exQuery);
            _snoop?.OnStrategized(parsed.UsedStrategy);


            var fetcher = Fetcher.Create(parsed, _options.Snooper);

            return (TResult)(object)fetcher.FetchFrom(SourceQuery);
        }



        public object Execute(Expression expression) {
            //Just delegate via refl to typed method...
            throw new NotImplementedException();
        }
        

    }

}
