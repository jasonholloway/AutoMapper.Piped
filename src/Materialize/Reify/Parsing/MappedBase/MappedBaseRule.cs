using Materialize.Reify.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Materialize.Reify.Parsing.MappedBase
{
    class MappedBaseRule : ParseRule
    {
        IMapStrategySource _mapStrategies;

        public MappedBaseRule(IMapStrategySource mapStrategies) {
            _mapStrategies = mapStrategies;
        }
        

        public override IParseStrategy GetStrategy(ParseContext ctx) 
        {
            if(ctx.IsMappingBase) 
            {                
                var mapStrategy = _mapStrategies.GetStrategy(ctx.MapContext);
                return new MappedBaseStrategy(mapStrategy);
            }
            
            return null;
        }
    }
}
