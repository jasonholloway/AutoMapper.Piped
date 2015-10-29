using Materialize.Expressions;
using Materialize.Reify2.Compiling;
using Materialize.Reify2.Mapping;
using Materialize.Reify2.Parsing2;
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

        //    public static Fetcher Create(/*Parser.Result*/ dynamic parseResult, ISnooper snooper = null) {
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

        //    public override object FetchFrom(IQueryable qySource) {
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



        abstract class Executor
        {
            protected IQueryable SourceQuery { get; private set; }
            protected IEnumerable<IOperation> ServerSteps { get; private set; }
            protected IEnumerable<IOperation> ClientSteps { get; private set; }

            public abstract object Execute();

            public static Executor Create(IQueryable qySource, LinkedList<IOperation> ops) 
            {
                var spec = BuildExecSpec(ops);

                var executor = (Executor)Activator.CreateInstance(
                                            typeof(Executor<,,>).MakeGenericType(
                                                                        typeof(TElem), 
                                                                        spec.SourceType, 
                                                                        spec.FetchType, 
                                                                        spec.DestType));
                executor.SourceQuery = qySource;
                executor.ServerSteps = spec.ServerSteps;
                executor.ClientSteps = spec.ClientSteps;

                return executor;
            }
        }


        class Executor<TSource, TFetch, TDest> : Executor
        {
            public override object Execute() 
            {                
                var exServerQuery = QueryWriter.Write(
                                                SourceQuery.Expression, 
                                                ServerSteps);
                
                var fetched = SourceQuery.Provider.Execute<TFetch>(exServerQuery);



                var exInput = Expression.Parameter(typeof(TFetch), "fetched");
                          
                var exTransform = TransformWriter.Write(exInput, ClientSteps);

                var fnTransform = Expression.Lambda<Func<TFetch, TDest>>(
                                                exTransform,
                                                exInput
                                                ).Compile();
                
                var transformed = fnTransform(fetched);
                
                return fetched;                                
            }
        }


        //need to assemble into a cacheable lump by parsing through elements
        //instead of knotting myself by limiting myself to various restrictive structures,
        //could instead make a nice doubly-linked list implementation...

        //each step would have a site, and through the site would be able to access before and after steps.

        //the eventual visitor could then go through the structure, recursively but linearly. 





        









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
            

            //parameterize here
            //...


            var subject = new ParseSubject(exQuery, _qySource.Expression, ctx);


            var ops = Parser.ParseAndPackage(subject);


            //optimize ops here
            //....
            
            var executor = Executor.Create(
                                    _qySource, 
                                    ops);
            
            return (TResult)executor.Execute();



            //create Executor class here...



            //in writing the source query and compiling the transformation, need to figure out the source type, the fetch type, and the destination type
            //these are all found 


            //The original query comes in, and we need to supply the mapping projections...
            //this is already done by Parser. At this point, these projections are in place
            //and are just to be optimised/executed


            //at the moment, I'm struggling with the inelegancy of execution.
            //it seems, to me at least, that fetching should be done as part of parsing.

            //Execute() would trigger this, then receive the results.
            //The parser would:
            //  populate a 1D buffer of steps (i.e. a list!)

            //The Executor would:
            //  traverse this list of steps, writing the source query, fetching and
            //  transforming via compilation.

            //  the runner would work out the fetch type, somehow...
            //  The OutType preceding the new source regime would determine the fetch type.

            
            







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






        //from parsed specs, need to form ExecutionSpec



        static ExecSpec BuildExecSpec(IEnumerable<IOperation> steps) {
            var serverSteps = new List<IOperation>();
            var clientSteps = new List<IOperation>();

            bool afterGap = false;

            foreach(var step in steps) {
                if(afterGap) clientSteps.Add(step);
                else serverSteps.Add(step);

                afterGap = afterGap | step.OpType.HasFlag(OpType.RegimeBoundary);
            }

            return new ExecSpec(serverSteps, clientSteps);
        }

        struct ExecSpec
        {
            public readonly IEnumerable<IOperation> ServerSteps;
            public readonly IEnumerable<IOperation> ClientSteps;

            public ExecSpec(
                IEnumerable<IOperation> serverSteps, 
                IEnumerable<IOperation> clientSteps)
            {
                ServerSteps = serverSteps;
                ClientSteps = clientSteps;
            }

            
            public Type SourceType {
                get { return ServerSteps.First().OutType; }
            }
            
            public Type FetchType {
                get { return ServerSteps.Last().OutType; }
            }

            public Type DestType {
                get { return ClientSteps.Last().OutType; }
            }

        }




    }

}
