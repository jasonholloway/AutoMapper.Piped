﻿using Materialize.Reify2.Mapping;
using Materialize.Reify2.Rebasing;
using Materialize.Types;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Materialize.Reify2.Parsing.Mapping
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
                var mapDestType = (Type)null;// ctx.ReifyContext.MapDestType;

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
