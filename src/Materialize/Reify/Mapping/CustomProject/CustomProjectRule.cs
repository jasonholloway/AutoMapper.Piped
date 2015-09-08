using AutoMapper;
using System;
using System.Linq;
using System.Linq.Expressions;
using JH.DynaType;
using System.Reflection;
using System.Collections.Concurrent;
using System.Collections.Generic;
using Materialize.TypeMaps;

namespace Materialize.Reify.Mapping.CustomProject
{
    class CustomProjectRule 
        : MapRuleBase
    {
        ITypeMapProvider _typeMaps;
        IMapStrategySource _mapStrategySource;


        public CustomProjectRule(
            ITypeMapProvider typeMaps,
            IMapStrategySource mapStrategySource) 
        {
            _typeMaps = typeMaps;
            _mapStrategySource = mapStrategySource;
        }

        
        public override IMapStrategy DeduceStrategy(MapContext ctx) 
        {
            var spec = ctx.TypeVector;
            var typeMap = _typeMaps.FindTypeMap(ctx.TypeVector);

            if(typeMap != null && typeMap.CustomProjection != null) 
            {
                //Projections DON'T cascade downwards - they project from the source type
                //into a tuple and then thereafter transform.

                //PropertyMaps however most certainly do!

                //So,

                //is projection edm-compatible?
                //  - then EdmFriendlyProjectionStrategy

                //does projection only require certain aspects of source?
                //  - then MediatedProjectionStrategy

                //default
                //  - FullProjectionStrategy

                //for now just render FullFetchAndProjectStrategy - should cover all bases, functionally
                


                return base.CreateStrategy(
                                typeof(FullFetchAndTransformStrategy<,>),
                                spec.SourceType,
                                spec.DestType,
                                new object[] {
                                    ctx,
                                    typeMap
                                });                
            }

            return null;
        }
    }



    //***************************************************
    //below should be tidied up

    struct DataType
    {
        public readonly Type Type;
        public readonly DataFieldMap[] FieldMaps;

        public DataType(Type type, DataFieldMap[] fieldMaps) {
            Type = type;
            FieldMaps = fieldMaps;
        }
    }

    struct DataFieldMap
    {
        public readonly FieldInfo Field;
        public readonly MemberInfo SourceMember;

        public DataFieldMap(FieldInfo field, MemberInfo sourceMember) {
            Field = field;
            SourceMember = sourceMember;
        }
    }





}
