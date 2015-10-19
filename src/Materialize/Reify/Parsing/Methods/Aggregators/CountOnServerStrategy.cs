using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using Materialize.Types;


namespace Materialize.Reify.Parsing.Methods.Aggregators
{
    //as always, no awareness here of changes to cardinality elsewhere...

    class CountOnServerStrategy<TSource, TElem> 
        : MethodStrategyBase<TSource, int>
    {
        MethodInfo _mCount; 

        public CountOnServerStrategy(IParseStrategy upstreamStrategy)
            : base(upstreamStrategy) 
        { 
            _mCount = QueryableMethods.Count
                            .MakeGenericMethod(FetchType.GetEnumerableElementType());
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
                        

            protected override Expression FetchMod(Expression exSourceQuery) {
                var exUpstream = UpstreamFetchMod(exSourceQuery);                
                return Expression.Call(_mCount, exUpstream);
            }


            protected override Expression TransformMod(Expression exQuery) {
                throw new NotImplementedException();
            }


            protected override int Transform(object fetched) {
                //no upstream delegation here: placing rule guarantees no intervening filtering
                return (int)fetched;
            }
        }

    }
}
