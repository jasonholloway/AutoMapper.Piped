using AutoMapper;
using System;
using System.Collections.Generic;
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
        

        IEnumerable<PropMapStrategySpec> CreatePropMapSpecs(ReifyContext ctx, IEnumerable<PropertyMap> propMaps) {
            return propMaps.Select(m => new PropMapStrategySpec(
                                                m, 
                                                DeduceStrategyForPropMap(ctx, m)));
        }

        IReifyStrategy DeduceStrategyForPropMap(ReifyContext ctx, PropertyMap map) {
            return ctx.Source.GetStrategy(
                                    ((PropertyInfo)map.SourceMember).PropertyType,
                                    map.DestinationPropertyType
                                    );
        }
        
    }
    






}
