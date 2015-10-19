using Materialize.Reify.Mapping;
using Materialize.Reify.Rebasing;
using Materialize.Types;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Materialize.Reify.Parsing.Mapping
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
                var mapDestType = ctx.ReifyContext.MapDestType;

                var sourceType = ctx.SourceType;

                var destType = typeof(IEnumerable<>).MakeGenericType(mapDestType); //sometimes this will not be ienumerable, but singular...
                
                var mapContext = new MapContext(
                                        new TypeVector(sourceType, destType),
                                        ctx.ReifyContext);
                
                var mapStrategy = _mapStrategies.GetStrategy(mapContext);
                
                return CreateStrategy(
                            typeof(MapperStrategy<,>).MakeGenericType(
                                                            sourceType, 
                                                            destType),
                            mapStrategy);
            }
            
            return null;
        }
    }
}
