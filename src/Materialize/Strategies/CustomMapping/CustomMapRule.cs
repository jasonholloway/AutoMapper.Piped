using AutoMapper;
using System;
using System.Linq;
using System.Linq.Expressions;
using JH.DynaType;
using System.Reflection;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace Materialize.Strategies.Projection
{
    class CustomMapRule : RuleBase
    {        
        public override IStrategy DeduceStrategy(Context ctx) 
        {
            var spec = ctx.TypeVector;
            var typeMap = ctx.TypeMap;

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
