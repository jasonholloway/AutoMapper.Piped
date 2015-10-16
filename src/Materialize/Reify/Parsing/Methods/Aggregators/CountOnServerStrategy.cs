using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using Materialize.Types;


namespace Materialize.Reify.Parsing.Methods.Aggregators
{
    class CountOnServerStrategy<TElem> 
        : MethodStrategyBase<IEnumerable<TElem>, int>
    {
        MethodInfo _mCount; 

        public CountOnServerStrategy(IParseStrategy upstreamStrategy)
            : base(upstreamStrategy) 
        { 
            FetchType = UpstreamStrategy.FetchType.GetEnumerableElementType();
            _mCount = QueryableMethods.Count.MakeGenericMethod(FetchType);
        }

        
        protected override IModifier Parse(IModifier upstreamMod, MethodCallExpression ex) 
        {
            return new Modifier(upstreamMod, _mCount);
        }
        


        class Modifier : ParseModifier<IEnumerable<TElem>, int>
        {
            MethodInfo _mCount;

            public Modifier(IModifier upstreamMod, MethodInfo mCount)
                : base(upstreamMod) 
            {
                _mCount = mCount;
            }
                        

            protected override Expression Rewrite(Expression exSourceQuery) 
            {
                var exUpstream = UpstreamRewrite(exSourceQuery);
                
                return Expression.Call(_mCount, exUpstream);
            }


            protected override int Transform(object fetched) {
                return (int)fetched;
            }
        }

    }
}
