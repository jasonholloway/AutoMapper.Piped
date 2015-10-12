using System;
using System.Linq;
using System.Reflection;
using Materialize.TypeMaps;

namespace Materialize.Reify.Mapping.Translation
{
    class CustomTranslationRule 
        : MapRuleBase
    {
        ITypeMapProvider _typeMaps;
        IMapStrategySource _mapStrategySource;


        public CustomTranslationRule(
            ITypeMapProvider typeMaps,
            IMapStrategySource mapStrategySource) 
        {
            _typeMaps = typeMaps;
            _mapStrategySource = mapStrategySource;
        }

        
        public override IMapStrategy DeduceStrategy(MapContext ctx) 
        {
            var typeMap = _typeMaps.FindTypeMap(ctx.TypeVector);    //EEEEEK!

            if(typeMap != null 
                && (typeMap.CustomProjection != null || typeMap.CustomMapper != null)) 
            {                
                if(typeMap.CustomMapper != null || !ctx.SourceRegime.ServerAccepts(typeMap.CustomProjection)) 
                {
                    return base.CreateStrategy(
                                    typeof(FullFetchAndTransformStrategy<,>),
                                    ctx.TypeVector,
                                    ctx,
                                    typeMap);
                }
                else {
                    return base.CreateStrategy(
                                    typeof(ServerFriendlyProjectStrategy<,>),
                                    ctx.TypeVector,
                                    ctx,
                                    typeMap);
                }                                
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
