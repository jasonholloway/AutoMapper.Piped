using System;
using System.Linq.Expressions;

namespace Materialize.Strategies.Direct
{
    class DirectRule : ReifyRuleBase
    {        
        public override IReifyStrategy DeduceStrategy(ReifyContext ctx) 
        {
            var spec = ctx.Spec;

            if(spec.SourceType == spec.DestType) 
            {
                return base.CreateStrategy(
                                    typeof(DirectStrategy<,>),
                                    spec.SourceType,
                                    spec.DestType,
                                    ctx);
            }

            return null;
        }
    }
    
}
