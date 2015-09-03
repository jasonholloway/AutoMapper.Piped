using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using Materialize.Projection;

namespace Materialize.Strategies.PropertyMapping
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
        
        public override IReifier<TOrig, TDest> CreateReifier() {            
            var reifierType = typeof(Reifier<>).MakeGenericType(typeof(TOrig), typeof(TDest), _projTypeInfo.Type);
            return (IReifier<TOrig, TDest>)Activator.CreateInstance(reifierType, _projTypeInfo);
        }





        class Reifier<TMed> : ReifierBase<TOrig, TMed, TDest>
        {
            Type _projType;
            MemberReifySpec[] _memberSpecs;            
            
            public Reifier(ProjectedTypeInfo<PropMapSpec> projTypeInfo) 
            {
                _projType = projTypeInfo.Type;

                _memberSpecs = projTypeInfo.Members.Select(m => new MemberReifySpec(
                                                                        m.Spec.PropMap,
                                                                        m.ProjectedField,
                                                                        m.Spec.Strategy.CreateReifier())
                                                                        ).ToArray();
            }
            
            protected override Expression ProjectSingle(Expression exSource) 
            {
                return Expression.MemberInit(
                                        Expression.New(_projType),
                                        _memberSpecs.Select(m => Expression.Bind(
                                                                        m.ProjectedField,
                                                                        m.Reifier.Project(
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

                    var transformedValue = memberSpec.Reifier.Transform(memberValue);
                    
                    memberSpec.PropertyMap.DestinationProperty.SetValue(dest, transformedValue);
                }

                return dest;
            }

            struct MemberReifySpec
            {
                public readonly PropertyMap PropertyMap;
                public readonly FieldInfo ProjectedField;
                public readonly IReifier Reifier;

                public MemberReifySpec(PropertyMap propMap, FieldInfo projField, IReifier reifier) {
                    PropertyMap = propMap;
                    ProjectedField = projField;
                    Reifier = reifier;
                }
            }

        }
    }

}
