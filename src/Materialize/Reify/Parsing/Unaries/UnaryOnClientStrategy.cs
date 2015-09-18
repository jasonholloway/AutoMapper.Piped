using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;


namespace Materialize.Reify.Parsing.Unaries
{
    class UnaryOnClientStrategy<TElem> 
        : QueryableMethodStrategy<IEnumerable<TElem>, TElem>
    {        
        public UnaryOnClientStrategy(IParseStrategy upstreamStrategy, MethodInfo mUnaryDef)
            : base(upstreamStrategy) 
        {
            FetchType = UpstreamStrategy.FetchType;

            throw new NotImplementedException();
        }
        

        protected override IModifier Parse(IModifier upstreamMod, MethodCallExpression ex) 
        {
            return new Modifier(upstreamMod);
        }
        

        class Modifier : ParseModifier<IEnumerable<TElem>, TElem>
        {
            public Modifier(IModifier upstreamMod)
                : base(upstreamMod) { }            
        
                
            protected override Expression Rewrite(Expression exSourceQuery) 
            {
                return UpstreamRewrite(exSourceQuery);
            }
            
            protected override TElem Transform(object fetched) 
            {
                var transformed = UpstreamTransform(fetched);
                return transformed.First();
            }
        }

    }
}
