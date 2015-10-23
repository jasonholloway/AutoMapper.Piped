using Materialize.Expressions;
using Materialize.Reify2.Mapping;
using Materialize.Reify2.Parsing2;
using Materialize.Reify2.QueryWriting;
using Materialize.SourceRegimes;
using Materialize.Types;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace Materialize.Reify2
{
    //Reifiables are mostly QueryProviders, serving ReifyQueries
    //As such, they orchestrate query-parsing, fetching and transformation, via a stack of modifiers.

    interface IReifiable : IQueryProvider
    { }


    class Reifiable<TElem> : IReifiable
    {
        //static PropertyInfo _baseReifyQueryProp = typeof(Reifiable<TSource, TMap>)
        //                                                .GetProperty(nameof(BaseReifyQuery));


        ISourceRegimeProvider _regimeSourceProv;
        MapperWriterSource _mapperWriterSource;
        MaterializeOptions _options;
        ISnooper _snoop;
        
        IQueryable<TElem> _qySource;

        
        //public IQueryable<TElem> SourceQuery { get; private set; }
        //public IQueryable<TMap> BaseReifyQuery { get; private set; }
        

        public Reifiable(
            IQueryable<TElem> sourceQuery, 
            ISourceRegimeProvider regimeSourceProv,
            MapperWriterSource mapperWriterSource,
            MaterializeOptions options)
        {
            _qySource = sourceQuery;

            //SourceQuery = sourceQuery;
            
            //_baseExp = Expression.Parameter(typeof(TElem), "source");

            //BaseReifyQuery = CreateQuery<TMap>(
            //                        Expression.MakeMemberAccess(
            //                                    Expression.Constant(this), 
            //                                    _baseReifyQueryProp)
            //                        );

            _regimeSourceProv = regimeSourceProv;
            _mapperWriterSource = mapperWriterSource;
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



        
        //static IQueryable PackageAsQueryable(Type tElem, IEnumerable items) 
        //{            
        //    var tCont = typeof(EnumerableQuery<>).MakeGenericType(tElem);
        //    return (IQueryable)Activator.CreateInstance(tCont, items);
        //}





        //abstract class Fetcher
        //{
        //    public abstract object FetchFrom(IQueryable qySource);

        //    public static Fetcher Create(/*Parser.Result*/ dynamic parseResult, ISnooper snooper = null) 
        //    {
        //        var tFetcher = typeof(Fetcher<,>).MakeGenericType(
        //                                                typeof(TSource),
        //                                                typeof(TMap),
        //                                                parseResult.UsedStrategy.FetchType,
        //                                                parseResult.UsedStrategy.DestType);

        //        return (Fetcher)Activator.CreateInstance(
        //                                            tFetcher,
        //                                            parseResult.Modifier,
        //                                            snooper); 
        //    }
        //}
        
        //class Fetcher<TFetch, TDest> : Fetcher
        //{
        //    IModifier _mod;
        //    ISnooper _snoop;

        //    public Fetcher(IModifier mod, ISnooper snooper) {
        //        _mod = mod;
        //        _snoop = snooper;
        //    }

        //    public override object FetchFrom(IQueryable qySource) 
        //    {
        //        var exFetch = _mod.ServerFilter(qySource.Expression);
        //        exFetch = _mod.ServerProject(exFetch);

        //        //var exFetch = _mod.FetchMod(qySource.Expression);                
        //        _snoop?.OnFetch(exFetch);
                                
        //        var fetched = qySource.Provider.Execute<TFetch>(exFetch);
        //        _snoop?.OnFetched(fetched);


        //        var exParam = Expression.Parameter(typeof(TFetch), "fetched");

        //        //var exBody = _mod.TransformMod(exParam);
        //        var exBody = _mod.ClientTransform(exParam);
        //        _snoop?.OnTransform(exBody);

        //        var exFnTransform = Expression.Lambda<Func<TFetch, TDest>>(exBody, exParam);

        //        var fnTransform = exFnTransform.Compile();

        //        var transformed = fnTransform(fetched);
        //        _snoop?.OnTransformed(transformed);

        //        return transformed;                
        //    }
        //}




        //modifier stack rewrites the SourceQuery expression
        //then compiles and executes transformation




                


        public TResult Execute<TResult>(Expression exQuery) 
        {
            if(!exQuery.Contains(_qySource.Expression)) {
                throw new InvalidOperationException("Bad query expression passed to Reifiable.Execute!");
            }

            _snoop?.OnQuery(exQuery);
            
            var ctx = new ReifyContext(
                            _options.MappingEngine,
                            _options.SourceRegime ?? _regimeSourceProv.GetRegime(_qySource),
                            _mapperWriterSource,
                            _options.AllowClientSideFiltering ?? false);
            
            var subject = new ParseSubject(exQuery, _qySource.Expression, ctx);

            var elements = SplitElements(Parser.Parse(subject));

                        
            var exServerQuery = QueryWriter.Write(_qySource.Expression, elements.ServerElements);

            

            //need to insert client transformation here...


            var fetched = _qySource.Provider.Execute<TResult>(exServerQuery);

            return fetched;

            //Squi


            throw new NotImplementedException();




            //dynamic _parserFac = null;

            //var parser = _parserFac.Create(
            //                            BaseReifyQuery.Expression, 
            //                            typeof(IQueryable<TSource>), 
            //                            reifyContext);
                        
            //var parsed = parser.Parse(exQuery);
            ////_snoop?.OnStrategized(parsed.UsedStrategy);


            //var fetcher = Fetcher.Create(parsed, _options.Snooper);

            //return (TResult)(object)fetcher.FetchFrom(SourceQuery);
        }



        public object Execute(Expression expression) {
            //Just delegate via refl to typed method...
            throw new NotImplementedException();
        }






        static Elements SplitElements(IEnumerable<IElement> els) {
            var serverEls = new List<IElement>();
            var clientEls = new List<IElement>();

            bool afterGap = false;

            foreach(var el in els) {
                if(afterGap) clientEls.Add(el);
                else serverEls.Add(el);

                afterGap = afterGap | el.ElementType.HasFlag(ElementType.RegimeBoundary);
            }

            return new Elements(serverEls, clientEls);
        }

        struct Elements
        {
            public readonly IEnumerable<IElement> ServerElements;
            public readonly IEnumerable<IElement> ClientElements;

            public Elements(IEnumerable<IElement> serverEls, IEnumerable<IElement> clientEls) {
                ServerElements = serverEls;
                ClientElements = clientEls;
            }
        }




    }

}
