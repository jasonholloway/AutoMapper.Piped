using AutoMapper;
using System;
using System.Linq;
using System.Reflection;

namespace Materialize.Strategies.PropertyMapping
{
    class PropertyMapRule : IReifyRule
    {
        ReifierSource _source;

        public PropertyMapRule(ReifierSource source) {
            _source = source;
        }

        public IReifyStrategy DeduceStrategy(ReifySpec spec) 
        {
            var typeMap = Mapper.FindTypeMapFor(spec.SourceType, spec.DestType);

            if(typeMap != null
                && typeMap.CustomProjection == null
                && typeMap.CustomMapper == null) 
                { 
                    var propSpecs = typeMap.GetPropertyMaps()
                                                .Select(map => PropMap2PropMapSpec(map))
                                                .ToArray();

                    var stratType = propSpecs.Any(s => s.Strategy.UsesIntermediateType)
                                        ? typeof(MediatedPropMapStrategy<,>)
                                        : typeof(SimplePropMapStrategy<,>);

                    return (IReifyStrategy)Activator.CreateInstance(
                                                        stratType.MakeGenericType(spec.SourceType, spec.DestType),
                                                        typeMap,
                                                        propSpecs);
                }

            return null;
        }
        
        PropMapSpec PropMap2PropMapSpec(PropertyMap map) 
        {
            var strategy = _source.GetStrategy(
                                    ((PropertyInfo)map.SourceMember).PropertyType,
                                    map.DestinationPropertyType);

            return new PropMapSpec(map, strategy);
        }        
    }
    






}
