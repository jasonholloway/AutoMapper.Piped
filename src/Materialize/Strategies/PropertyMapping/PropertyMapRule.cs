using AutoMapper;
using System;
using System.Linq;
using System.Reflection;

namespace Materialize.Strategies.PropertyMapping
{
    class PropertyMapRule : ReifyRuleBase
    {
        public override IReifyStrategy DeduceStrategy(ReifyContext ctx) 
        {
            var spec = ctx.Spec;
            var typeMap = ctx.TypeMap;

            if(typeMap != null
                && typeMap.CustomProjection == null
                && typeMap.CustomMapper == null) 
                { 
                    var propSpecs = typeMap.GetPropertyMaps()
                                                .Select(map => PropMap2PropMapSpec(ctx, map))
                                                .ToArray();

                    var stratType = propSpecs.Any(s => s.Strategy.UsesIntermediateType)
                                        ? typeof(MediatedPropMapStrategy<,>)
                                        : typeof(SimplePropMapStrategy<,>);

                    return base.CreateStrategy(
                                        stratType,
                                        spec.SourceType,
                                        spec.DestType,
                                        ctx,
                                        typeMap,
                                        propSpecs);
                }

            return null;
        }
        
        PropMapSpec PropMap2PropMapSpec(ReifyContext ctx, PropertyMap map) 
        {
            var strategy = ctx.Source.GetStrategy(
                                        ((PropertyInfo)map.SourceMember).PropertyType,
                                        map.DestinationPropertyType);

            return new PropMapSpec(map, strategy);
        }        
    }
    






}
