using Materialize.Reify.Mapping;
using Materialize.Reify.Rebasing;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Materialize.Reify.Parsing.Mapper
{
    class MapperRule : ParseRule
    {
        IMapStrategySource _mapStrategies;

        public MapperRule(IMapStrategySource mapStrategies) {
            _mapStrategies = mapStrategies;
        }
        

        public override IParseStrategy GetStrategy(ParseContext ctx) 
        {
            if(ctx.IsMappingBase) 
            {
                var mapContext = new MapContext(
                                        ctx.ReifyContext.RootTypeVector,
                                        ctx.ReifyContext);
                
                var mapStrategy = _mapStrategies.GetStrategy(mapContext);

                return new MapperStrategy(mapStrategy);
            }
            
            return null;
        }
    }
}
