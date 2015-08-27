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

        public IReifierFactory BuildFactoryIfApplicable(ReifySpec spec) 
        {
            var typeMap = Mapper.FindTypeMapFor(spec.SourceType, spec.DestType);

            if(typeMap != null && typeMap.CustomProjection == null) {
                var facType = typeof(PropertyMapReifierFactory<,>).MakeGenericType(spec.SourceType, spec.DestType);
                return (IReifierFactory)Activator.CreateInstance(facType, typeMap, _source);
            }

            return null;
        }
    }
    

    class PropertyMapReifierFactory<TOrig, TDest>
        : ReifierFactory<TOrig, TDest>
    {
        PropSpec[] _propSpecs;

        public PropertyMapReifierFactory(TypeMap typeMap, ReifierSource source) 
        {
            _propSpecs = typeMap.GetPropertyMaps()
                                    .Select(map => new PropSpec(map, 
                                                            source.GetReifierFactory(((PropertyInfo)map.SourceMember).PropertyType, map.DestinationPropertyType)))
                                    .ToArray();                 
        }

        public override IReifier<TOrig, TDest> CreateReifier(ReifyContext ctx) {
            return new PropertyMapReifier<TOrig, TDest>(ctx, _propSpecs);
        }
    }


    struct PropSpec
    {
        public readonly PropertyMap Map;
        public readonly IReifierFactory ReifierFactory; 

        public PropSpec(PropertyMap map, IReifierFactory factory) {
            Map = map;
            ReifierFactory = factory;
        }
    }


    class PropertyMapReifier<TOrig, TDest>
        : ReifierBase<TOrig, TDest>
    {
        ReifyContext _ctx;
        PropSpec[] _propSpecs;

        public PropertyMapReifier(ReifyContext ctx, PropSpec[] propSpecs) {
            _ctx = ctx;
            _propSpecs = propSpecs;
        }


        MemberBinding[] BuildBindings(Expression exSource) {
            return _propSpecs.Select(
                        spec => {
                            var sourceMember = spec.Map.SourceMember;
                            var destMember = spec.Map.DestinationProperty.MemberInfo;
                            var subReifier = spec.ReifierFactory.CreateReifier(_ctx);

                            var exInput = Expression.MakeMemberAccess(
                                                                exSource,
                                                                sourceMember);

                            var exMappedInput = subReifier.Map(exInput);

                            return Expression.Bind(
                                                destMember,
                                                exMappedInput);
                        }).ToArray();
        }


        protected override Expression MapSingle(Expression exSource) 
        {            
            return Expression.MemberInit( //should handle custom ctors etc.
                                Expression.New(typeof(TDest).GetConstructors().First()),
                                BuildBindings(exSource)
                                );
        }

                
        protected override TDest FinalizeSingle(object obj) {
            throw new NotImplementedException();
        }

    }



}
