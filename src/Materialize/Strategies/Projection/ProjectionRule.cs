using AutoMapper;
using System;
using System.Linq;
using System.Linq.Expressions;
using JH.DynaType;
using System.Reflection;

namespace Materialize.Strategies.Projection
{
    class ProjectionRule : IReifyRule
    {
        ReifierSource _source;

        public ProjectionRule(ReifierSource source) {
            _source = source;
        }

        public IReifyStrategy DeduceStrategy(ReifySpec spec) 
        {
            var typeMap = Mapper.FindTypeMapFor(spec.SourceType, spec.DestType);

            if(typeMap != null && typeMap.CustomProjection != null) 
            {
                //test for edm compatibility of projection
                //...
                
                //can we deduce needed member values?
                //...

                

                var strategyType = typeof(MediatedProjectionStrategy<,>).MakeGenericType(spec.SourceType, spec.DestType);
                return (IReifyStrategy)Activator.CreateInstance(strategyType, typeMap);
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
