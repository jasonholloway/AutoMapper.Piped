using AutoMapper;
using System;
using System.Linq;
using System.Linq.Expressions;
using JH.DynaType;
using System.Reflection;

namespace Materialize.Strategies.Projection
{
    class ProjectionRule : ReifyRuleBase
    {        
        public override IReifyStrategy DeduceStrategy(ReifyContext ctx) 
        {
            var spec = ctx.Spec;
            var typeMap = ctx.TypeMap;

            if(typeMap != null && typeMap.CustomProjection != null) 
            {
                //test for edm compatibility of projection
                //...

                //can we deduce needed member values?
                //...


                return base.CreateStrategy(
                                typeof(MediatedProjectionStrategy<,>),
                                spec.SourceType,
                                spec.DestType,
                                ctx,
                                typeMap);
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
