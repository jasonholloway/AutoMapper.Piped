using Materialize.Reify.Mapping;
using Materialize.Reify.Parsing;
using Materialize.Reify.Parsing.CallParsing;
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

        public event EventHandler<IQueryable> Queried;
        public event EventHandler<IEnumerable> Fetched;
        public event EventHandler<IEnumerable> Transformed;

        protected void OnQueried(IQueryable query) {
            if(Queried != null) {
                Queried(this, query);
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

        Lazy<IMapStrategy> _lzMapStrategy;
        ICallParseStrategySource _callParsers;

        public IQueryable<TSource> SourceQuery { get; private set; }
        public IQueryable<TDest> BaseReifyQuery { get; private set; }


        public Reifiable(
            IQueryable<TSource> sourceQuery, 
            Func<IMapStrategy> fnMapStrategy,
            ICallParseStrategySource callParsers) 
        {
            SourceQuery = sourceQuery;

            BaseReifyQuery = CreateQuery<TDest>(
                                    Expression.MakeMemberAccess(
                                                Expression.Constant(this), 
                                                _baseReifyQueryProp)
                                    );

            _lzMapStrategy = new Lazy<IMapStrategy>(fnMapStrategy);

            _callParsers = callParsers;
        }
        


        public override IQueryable<TElement> CreateQuery<TElement>(Expression expression) {
            return new ReifyQuery<TElement>(this, expression);
        }


        public override IQueryable CreateQuery(Expression expression) {
            //Just delegate via refl to typed method...
            throw new NotImplementedException();
        }



        public override TResult Execute<TResult>(Expression exReifyQuery) 
        {
            //parser creates modifier stack based on passed ReifyQuery expression
            //the core of the stack is provided by the selected mapping strategy
            //and only amended by the query parser
            var mapperModifier = _lzMapStrategy.Value.CreateModifier();

            var parser = new Parser(
                                BaseReifyQuery.Expression,
                                mapperModifier, //the modifier stack created by the mapper is fed in as base to the parser
                                _callParsers);

            var modifierStack = parser.Parse(exReifyQuery);
                                                            

            //modifier stack rewrites the SourceQuery expression
            var exQuery = modifierStack.Rewrite(SourceQuery.Expression);
            

            //fetch from source; transform fetched via modifiers                                    
            if(typeof(IQueryable).IsAssignableFrom(exQuery.Type)) {
                var query = SourceQuery.Provider.CreateQuery(exQuery);
                OnQueried(query);

                var enFetched = (IEnumerable)query;

                OnFetched(enFetched);

                var transformed = modifierStack.Transform(enFetched);
                
                OnTransformed(transformed is IEnumerable
                                    ? (IEnumerable)transformed
                                    : new[] { transformed });

                return (TResult)transformed;
            }
            else {
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
