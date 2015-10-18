using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using Materialize.Types;


namespace Materialize.Reify.Parsing.Methods.Aggregators
{
    class CountOnClientStrategy<TSource, TElem> 
        : MethodStrategyBase<TSource, int>
    {
        public CountOnClientStrategy(IParseStrategy upstreamStrategy)
            : base(upstreamStrategy) { }

        
        protected override IModifier Parse(IModifier upstreamMod, MethodCallExpression ex) 
        {
            return new Modifier(upstreamMod);
        }
        

        class Modifier : ParseModifier<IQueryable<TElem>, int>
        {
            public Modifier(IModifier upstreamMod)
                : base(upstreamMod) { }
                                    

            protected override Expression Rewrite(Expression exSourceQuery) {
                return UpstreamRewrite(exSourceQuery);
            }
            
            protected override int Transform(object fetched) {                
                var transformed = UpstreamTransform(fetched);
                return transformed.Count();
            }
        }

    }
}
