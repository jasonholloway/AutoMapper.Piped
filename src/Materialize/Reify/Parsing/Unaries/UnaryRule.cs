using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Materialize.Reify.Parsing.Unaries
{
    class UnaryRule : QueryableMethodRule
    {
        static IDictionary<MethodInfo, Type> _dStrategies
            = new Dictionary<MethodInfo, Type>() {
                {
                    Refl.GetGenMethod(() => Queryable.First<int>(null)),
                    typeof(FirstStrategy<>)
                },
                {
                    Refl.GetGenMethod(() => Queryable.FirstOrDefault<int>(null)),
                    typeof(FirstOrDefaultStrategy<>)
                },
            };

        
        public UnaryRule(IParseStrategySource strategySource)
            : base(strategySource) { }
        
        
        public override IParseStrategy GetStrategy(ParseContext ctx) 
        {
            if(ctx.MethodDef != null && ctx.TypeArgs.Length == 1) 
            {
                Type tStrategy = null;

                if(_dStrategies.TryGetValue(ctx.MethodDef, out tStrategy)) {
                    var tElem = ctx.TypeArgs.First();

                    var upstreamStrategy = GetUpstreamStrategy(ctx);

                    return CreateStrategy(
                                    tStrategy.MakeGenericType(tElem),
                                    upstreamStrategy);
                }
            }

            return null;
        }
    }
}
