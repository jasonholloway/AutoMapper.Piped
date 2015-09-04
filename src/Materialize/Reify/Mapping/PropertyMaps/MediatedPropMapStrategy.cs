using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using Materialize.Projection;
using Materialize.Reify.Mods;

namespace Materialize.Reify.Mapping.PropertyMaps
{
    class MediatedPropMapStrategy<TOrig, TDest>
        : StrategyBase<TOrig, TDest>
    {
        Context _ctx;
        TypeMap _typeMap;
        ProjectedTypeInfo<PropMapSpec> _projTypeInfo;

        public MediatedPropMapStrategy(Context ctx, TypeMap typeMap, PropMapSpec[] propMapSpecs) {
            _ctx = ctx;
            _typeMap = typeMap;
            _projTypeInfo = ctx.ProjectedTypeBuilder.BuildType(propMapSpecs);
        }
        
        public override Type ProjectedType {
            get { return _projTypeInfo.Type; }
        }
        
        public override IModifier CreateModifier() {            
            var mapperType = typeof(Mapper<>).MakeGenericType(typeof(TOrig), typeof(TDest), _projTypeInfo.Type);
            return (IModifier)Activator.CreateInstance(mapperType, _projTypeInfo);
        }





        class Mapper<TMed> : MapperBase<TOrig, TMed, TDest>
        {
            Type _projType;
            MemberReifySpec[] _memberSpecs;            
            
            public Mapper(ProjectedTypeInfo<PropMapSpec> projTypeInfo) 
            {
                _projType = projTypeInfo.Type;

                _memberSpecs = projTypeInfo.Members.Select(m => new MemberReifySpec(
                                                                        m.Spec.PropMap,
                                                                        m.ProjectedField,
                                                                        m.Spec.Strategy.CreateModifier())
                                                                        ).ToArray();
            }
            
            protected override Expression ProjectSingle(Expression exSource) 
            {
                return Expression.MemberInit(
                                        Expression.New(_projType),
                                        _memberSpecs.Select(m => Expression.Bind(
                                                                        m.ProjectedField,
                                                                        m.Mapper.RewriteQuery(
                                                                                    Expression.MakeMemberAccess(exSource, m.PropertyMap.SourceMember))
                                                                        )).ToArray());
            }
                        
            protected override TDest TransformSingle(TMed obj) 
            {
                //should use more elegant per-strategy-compiled ctor + binders
                //...

                var dest = Activator.CreateInstance<TDest>();

                foreach(var memberSpec in _memberSpecs) {
                    var memberValue = memberSpec.ProjectedField.GetValue(obj);

                    var transformedValue = memberSpec.Mapper.TransformFetched(memberValue);
                    
                    memberSpec.PropertyMap.DestinationProperty.SetValue(dest, transformedValue);
                }

                return dest;
            }

            struct MemberReifySpec
            {
                public readonly PropertyMap PropertyMap;
                public readonly FieldInfo ProjectedField;
                public readonly IModifier Mapper;

                public MemberReifySpec(PropertyMap propMap, FieldInfo projField, IModifier mapper) {
                    PropertyMap = propMap;
                    ProjectedField = projField;
                    Mapper = mapper;
                }
            }

        }
    }

}
