using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using Materialize.Types;


namespace Materialize.Reify.Parsing.Methods.Aggregators
{
    class CountOnClientStrategy<TElem> 
        : MethodStrategyBase<IEnumerable<TElem>, int>
    {
        public CountOnClientStrategy(IParseStrategy upstreamStrategy)
            : base(upstreamStrategy) 
        { 
            FetchType = UpstreamStrategy.FetchType.GetEnumerableElementType();
        }

        
        protected override IModifier Parse(IModifier upstreamMod, MethodCallExpression ex) 
        {
            return new Modifier(upstreamMod);
        }
        


        class Modifier : ParseModifier<IEnumerable<TElem>, int>
        {
            public Modifier(IModifier upstreamMod)
                : base(upstreamMod) { }
                                    

            protected override Expression Rewrite(Expression exSourceQuery) 
            {
                return UpstreamRewrite(exSourceQuery);
            }


            protected override int Transform(object fetched) {
                return ((IEnumerable<TElem>)fetched).Count();
            }
        }

    }
}
