using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Materialize.Reify.Parsing.Unaries
{
    class UnaryRule : ParseRule
    {
        static IDictionary<MethodInfo, Type> _dStrategies
            = new Dictionary<MethodInfo, Type>() {
                {
                    Refl.GetGenericMethodDef(() => Queryable.First<int>(null)),
                    typeof(FirstStrategy<>)
                },
                {
                    Refl.GetGenericMethodDef(() => Queryable.FirstOrDefault<int>(null)),
                    typeof(FirstOrDefaultStrategy<>)
                },
            };


        IParseStrategySource _strategySource;
        

        public UnaryRule(IParseStrategySource strategySource) {
            _strategySource = strategySource;
        }
        
        
        public override IParseStrategy GetStrategy(ParseContext ctx) 
        {
            if(ctx.MethodDef != null && ctx.TypeArgs.Length == 1) 
            {
                Type tStrategy = null;

                if(_dStrategies.TryGetValue(ctx.MethodDef, out tStrategy)) {
                    var tElem = ctx.TypeArgs.First();

                    var upstreamContext = ctx.Spawn(ctx.CallExp.Arguments.First());         //could be hived off to base class I reckon!
                    var upstreamStrategy = _strategySource.GetStrategy(upstreamContext);

                    return base.CreateStrategy(
                                    tStrategy.MakeGenericType(tElem),
                                    upstreamStrategy);
                }
            }

            return null;
        }
    }
}
