using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Materialize.Strategies.PropertyMapping
{
    class PropertyMapRule : RuleBase
    {
        public override IStrategy DeduceStrategy(Context ctx) 
        {
            var spec = ctx.TypeVector;
            var typeMap = ctx.TypeMap;

            if(typeMap != null
                && typeMap.CustomProjection == null
                && typeMap.CustomMapper == null) 
                {
                    var propMapSpecs = CreatePropMapSpecs(ctx, typeMap.GetPropertyMaps())
                                                            .ToArray();
                                
                    var strategyType = propMapSpecs.Any(s => s.Strategy.UsesIntermediateType)
                                            ? typeof(MediatedPropMapStrategy<,>)
                                            : typeof(SimplePropMapStrategy<,>);

                    return base.CreateStrategy(
                                        strategyType,
                                        spec.SourceType,
                                        spec.DestType,
                                        ctx,
                                        typeMap,
                                        propMapSpecs);
                }

            return null;
        }
        

        IEnumerable<PropMapSpec> CreatePropMapSpecs(Context ctx, IEnumerable<PropertyMap> propMaps) {
            return propMaps.Select(propMap => new PropMapSpec(
                                                        propMap, 
                                                        DeduceStrategyForPropMap(ctx, propMap)));
        }

        IStrategy DeduceStrategyForPropMap(Context ctx, PropertyMap map) 
        {
            var tOrig = ((PropertyInfo)map.SourceMember).PropertyType;
            var tDest = map.DestinationPropertyType;

            return ctx.StrategySource.GetStrategy(tOrig, tDest);
        }
        
    }
    






}
