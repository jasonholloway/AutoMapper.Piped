using AutoMapper;
using Materialize.Reify.Modifiers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Materialize.Reify.Mapping.PropertyMaps
{
    class SimplePropMapStrategy<TOrig, TDest>
        : StrategyBase<TOrig, TDest>
    {
        MapContext _ctx;
        PropMapSpec[] _propMapSpecs;

        public SimplePropMapStrategy(MapContext ctx, TypeMap typeMap, PropMapSpec[] propMapSpecs) {
            _ctx = ctx;
            _propMapSpecs = propMapSpecs;
        }


        public override Type FetchedType {
            get { return typeof(TDest); }
        }
        

        public override IModifier CreateModifier() {
            return new Mapper(_ctx, _propMapSpecs);
        }



        class Mapper : MapperModifier<TOrig, TDest, TDest>
        {
            MapContext _ctx;
            PropMapSpec[] _propSpecs;

            public Mapper(MapContext ctx, PropMapSpec[] propSpecs) {
                _ctx = ctx;
                _propSpecs = propSpecs;
            }


            MemberBinding[] BuildBindings(Expression exSource) {
                return _propSpecs.Select(
                            spec => {
                                var sourceMember = spec.PropMap.SourceMember;
                                var destMember = spec.PropMap.DestinationProperty.MemberInfo;
                                var subMapper = spec.Strategy.CreateModifier(); //this should be cached in strategy...

                                var exInput = Expression.MakeMemberAccess(
                                                                    exSource,
                                                                    sourceMember);

                                var exMappedInput = subMapper.Rewrite(exInput);

                                return Expression.Bind(
                                                    destMember,
                                                    exMappedInput);
                            }).ToArray();
            }


            public override Expression Rewrite(Expression exSource) {
                return Expression.MemberInit( //should handle custom ctors etc.
                                    Expression.New(typeof(TDest).GetConstructors().First()),
                                    BuildBindings(exSource)
                                    );
            }


            protected override TDest Transform(TDest obj) {
                return obj;
            }

        }
        
    }

}
