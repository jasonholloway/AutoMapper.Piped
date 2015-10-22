using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using Materialize.Types;


namespace Materialize.Reify2.Parsing.Methods.Aggregators
{
    //as always, no awareness here of changes to cardinality elsewhere...

    class CountOnServerStrategy<TSource, TElem> 
        : MethodStrategyBase<TSource, int>
    {
        MethodInfo _mCount; 

        public CountOnServerStrategy(IParseStrategy upstreamStrategy)
            : base(upstreamStrategy) 
        {
            FetchType = typeof(int);

            _mCount = QueryableMethods.Count
                            .MakeGenericMethod(UpstreamStrategy.SourceType.GetEnumerableElementType());
        }

        
        protected override IModifier Parse(IModifier upstreamMod, MethodCallExpression ex) 
        {
            return new Modifier(upstreamMod, _mCount);
        }
        


        class Modifier : ParseModifier<IQueryable<TElem>, int>
        {
            MethodInfo _mCount;

            public Modifier(IModifier upstreamMod, MethodInfo mCount)
                : base(upstreamMod) 
            {
                _mCount = mCount;
            }



            protected override Expression ServerFilter(Expression exQuery) {
                var exUpstreamRewritten = UpstreamServerFilter(exQuery);
                return Expression.Call(_mCount, exUpstreamRewritten);
            }

            protected override Expression ServerProject(Expression exQuery) {
                return exQuery; //short-circuit
            }

            protected override Expression ClientTransform(Expression exTransform) {
                return exTransform; //short-circuit
            }




            //protected override Expression FetchMod(Expression exSourceQuery) {
            //    var exUpstream = UpstreamFetchMod(exSourceQuery);                
            //    return Expression.Call(_mCount, exUpstream);
            //}


            //protected override Expression TransformMod(Expression exQuery) {
            //    return exQuery;
            //}
            

            //protected override int Transform(object fetched) {
            //    //no upstream delegation here: placing rule guarantees no intervening filtering
            //    return (int)fetched;
            //}
        }

    }
}
