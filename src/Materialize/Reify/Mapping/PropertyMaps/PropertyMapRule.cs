using AutoMapper;
using Materialize.ProjectedTypes;
using Materialize.TypeMaps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Materialize.Reify.Mapping.PropertyMaps
{
    class PropertyMapRule : MapRuleBase
    {
        ITypeMapProvider _typeMaps;
        IMapStrategySource _mapStrategySource;
        IProjectedTypeBuilder _typeBuilder;
        
        public PropertyMapRule(
            ITypeMapProvider typeMaps,
            IMapStrategySource mapStrategySource,
            IProjectedTypeBuilder typeBuilder) 
        {
            _typeMaps = typeMaps;
            _mapStrategySource = mapStrategySource;
            _typeBuilder = typeBuilder;
        }


        public override IMapStrategy DeduceStrategy(MapContext ctx) 
        {
            var spec = ctx.TypeVector;
            var typeMap = _typeMaps.FindTypeMap(ctx.TypeVector);

            if(typeMap != null
                && typeMap.CustomProjection == null
                && typeMap.CustomMapper == null) 
                {
                    var propMapSpecs = CreatePropMapSpecs(ctx, typeMap.GetPropertyMaps())
                                                    .ToArray();
                                
                    if(propMapSpecs.Any(s => s.Strategy.UsesIntermediateType)) {
                        return base.CreateStrategy(
                                        typeof(MediatedPropMapStrategy<,>),
                                        spec.SourceType,
                                        spec.DestType,
                                        ctx,
                                        typeMap,
                                        propMapSpecs,
                                        _typeBuilder);
                    }
                    else {
                        return base.CreateStrategy(
                                        typeof(SimplePropMapStrategy<,>),
                                        spec.SourceType,
                                        spec.DestType,
                                        ctx,
                                        typeMap,
                                        propMapSpecs);                                    
                    }
                }

            return null;
        }
        

        IEnumerable<PropMapSpec> CreatePropMapSpecs(MapContext ctx, IEnumerable<PropertyMap> propMaps) 
        {
            return propMaps.Select(propMap => new PropMapSpec(
                                                        propMap, 
                                                        DeduceStrategyForPropMap(ctx, propMap)));
        }


        IMapStrategy DeduceStrategyForPropMap(MapContext ctx, PropertyMap map) 
        {
            var tOrig = ((PropertyInfo)map.SourceMember).PropertyType;
            var tDest = map.DestinationPropertyType;

            return _mapStrategySource.GetStrategy(
                                            ctx.QueryRegime, 
                                            tOrig, 
                                            tDest);
        }
        
    }
    






}
