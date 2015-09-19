using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using Materialize.ProjectedTypes;

namespace Materialize.Reify.Mapping.PropertyMaps
{
    class MediatedPropMapStrategy<TOrig, TDest>
        : StrategyBase<TOrig, TDest>
    {
        MapContext _ctx;
        TypeMap _typeMap;
        ProjectedTypeInfo<PropMapSpec> _projTypeInfo;

        public MediatedPropMapStrategy(
            MapContext ctx, 
            TypeMap typeMap, 
            PropMapSpec[] propMapSpecs,
            IProjectedTypeBuilder typeBuilder) 
        {
            _ctx = ctx;
            _typeMap = typeMap;
            _projTypeInfo = typeBuilder.BuildType(propMapSpecs);
        }
        
        public override Type FetchType {
            get { return _projTypeInfo.Type; }
        }
        
        public override IModifier CreateModifier() {            
            var mapperType = typeof(Mapper<>).MakeGenericType(typeof(TOrig), typeof(TDest), _projTypeInfo.Type);
            return (IModifier)Activator.CreateInstance(mapperType, _projTypeInfo);
        }





        class Mapper<TMed> : MapperModifier<TOrig, TMed, TDest>
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
            
            public override Expression Rewrite(Expression exSource) 
            {
                return Expression.MemberInit(
                                        Expression.New(_projType),
                                        _memberSpecs.Select(m => Expression.Bind(
                                                                        m.ProjectedField,
                                                                        m.Mapper.Rewrite(
                                                                            Expression.MakeMemberAccess(exSource, m.PropertyMap.SourceMember))
                                                                        )
                                                            ).ToArray());
            }
                        
            protected override TDest Transform(TMed obj) 
            {
                //should use more elegant per-strategy-compiled ctor + binders
                //...

                var dest = Activator.CreateInstance<TDest>();

                foreach(var memberSpec in _memberSpecs) {
                    var memberValue = memberSpec.ProjectedField.GetValue(obj);

                    var transformedValue = memberSpec.Mapper.Transform(memberValue);
                    
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
