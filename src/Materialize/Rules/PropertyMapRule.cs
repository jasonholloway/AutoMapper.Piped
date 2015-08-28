using AutoMapper;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace Materialize.Rules
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
                                                .Select(map => PropMap2PropSpec(map))
                                                .ToArray();

                    var stratType = propSpecs.Any(s => s.Strategy.UsesIntermediateType)
                                        ? typeof(IndirectPropertyMapStrategy<,>)
                                        : typeof(DirectPropertyMapStrategy<,>);

                    return (IReifyStrategy)Activator.CreateInstance(
                                                        stratType.MakeGenericType(spec.SourceType, spec.DestType),
                                                        typeMap,
                                                        propSpecs);
                }

            return null;
        }
        
        PropSpec PropMap2PropSpec(PropertyMap map) 
        {
            var strategy = _source.GetStrategy(
                                    ((PropertyInfo)map.SourceMember).PropertyType,
                                    map.DestinationPropertyType);

            return new PropSpec(map, strategy);
        }        
    }
    

    struct PropSpec
    {
        public readonly PropertyMap PropMap;
        public readonly IReifyStrategy Strategy;

        public PropSpec(PropertyMap propMap, IReifyStrategy strategy) {
            PropMap = propMap;
            Strategy = strategy;
        }
    }
    


    class DirectPropertyMapStrategy<TOrig, TDest>
        : ReifierStrategy<TOrig, TDest>
    {
        PropSpec[] _propSpecs;

        public DirectPropertyMapStrategy(TypeMap typeMap, PropSpec[] propSpecs) { 
            _propSpecs = propSpecs;
        }

        public override bool UsesIntermediateType {
            get { return false; }
        }

        public override IReifier<TOrig, TDest> CreateReifier(ReifyContext ctx) {
            return new Reifier(ctx, _propSpecs);
        }



        class Reifier : ReifierBase<TOrig, TDest>
        {
            ReifyContext _ctx;
            PropSpec[] _propSpecs;

            public Reifier(ReifyContext ctx, PropSpec[] propSpecs) {
                _ctx = ctx;
                _propSpecs = propSpecs;
            }


            MemberBinding[] BuildBindings(Expression exSource) {
                return _propSpecs.Select(
                            spec => {
                                var sourceMember = spec.PropMap.SourceMember;
                                var destMember = spec.PropMap.DestinationProperty.MemberInfo;
                                var subReifier = spec.Strategy.CreateReifier(_ctx);

                                var exInput = Expression.MakeMemberAccess(
                                                                    exSource,
                                                                    sourceMember);

                                var exMappedInput = subReifier.Map(exInput);

                                return Expression.Bind(
                                                    destMember,
                                                    exMappedInput);
                            }).ToArray();
            }


            protected override Expression MapSingle(Expression exSource) {
                return Expression.MemberInit( //should handle custom ctors etc.
                                    Expression.New(typeof(TDest).GetConstructors().First()),
                                    BuildBindings(exSource)
                                    );
            }


            protected override TDest ReformSingle(object obj) {
                throw new NotImplementedException();
            }

        }


    }



    class IndirectPropertyMapStrategy<TOrig, TDest>
        : ReifierStrategy<TOrig, TDest>
    {
        TypeMap _typeMap;
        PropSpec[] _propSpecs;

        public IndirectPropertyMapStrategy(TypeMap typeMap, PropSpec[] propSpecs) {
            _typeMap = typeMap;
            _propSpecs = propSpecs;
        }

        public override bool UsesIntermediateType {
            get { return true; }
        }

        public override IReifier<TOrig, TDest> CreateReifier(ReifyContext ctx) {
            throw new NotImplementedException();
        }
    }


}
