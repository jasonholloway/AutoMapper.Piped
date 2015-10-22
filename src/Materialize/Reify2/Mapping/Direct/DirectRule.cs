using System;
using System.Linq.Expressions;

namespace Materialize.Reify2.Mapping.Direct
{
    class DirectRule : MapRuleBase
    {        
        public override IMapStrategy DeduceStrategy(MapContext ctx) 
        {
            var types = ctx.TypeVector;

            if(types.DestType.IsAssignableFrom(types.SourceType)) 
            {
                return base.CreateStrategy(
                                    typeof(DirectStrategy<,>),
                                    types,
                                    ctx);
            }

            return null;
        }
    }
    
}
