using System;
using System.Linq.Expressions;

namespace Materialize.Reify.Mapping.Direct
{
    class DirectRule : MapRuleBase
    {        
        public override IMapStrategy DeduceStrategy(Context ctx) 
        {
            var spec = ctx.TypeVector;

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
