using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Materialize.Strategies.PropertyMapping
{
    class SimplePropMapStrategy<TOrig, TDest>
        : StrategyBase<TOrig, TDest>
    {
        Context _ctx;
        PropMapSpec[] _propMapSpecs;

        public SimplePropMapStrategy(Context ctx, TypeMap typeMap, PropMapSpec[] propMapSpecs) {
            _ctx = ctx;
            _propMapSpecs = propMapSpecs;
        }


        public override Type ProjectedType {
            get { return typeof(TDest); }
        }
        

        public override IReifier<TOrig, TDest> CreateReifier() {
            return new Reifier(_ctx, _propMapSpecs);
        }



        class Reifier : ReifierBase<TOrig, TDest>
        {
            Context _ctx;
            PropMapSpec[] _propSpecs;

            public Reifier(Context ctx, PropMapSpec[] propSpecs) {
                _ctx = ctx;
                _propSpecs = propSpecs;
            }


            MemberBinding[] BuildBindings(Expression exSource) {
                return _propSpecs.Select(
                            spec => {
                                var sourceMember = spec.PropMap.SourceMember;
                                var destMember = spec.PropMap.DestinationProperty.MemberInfo;
                                var subReifier = spec.Strategy.CreateReifier(); //this should be cached in strategy...

                                var exInput = Expression.MakeMemberAccess(
                                                                    exSource,
                                                                    sourceMember);

                                var exMappedInput = subReifier.Project(exInput);

                                return Expression.Bind(
                                                    destMember,
                                                    exMappedInput);
                            }).ToArray();
            }


            protected override Expression ProjectSingle(Expression exSource) {
                return Expression.MemberInit( //should handle custom ctors etc.
                                    Expression.New(typeof(TDest).GetConstructors().First()),
                                    BuildBindings(exSource)
                                    );
            }


            protected override TDest TransformSingle(TDest obj) {
                return obj;
            }

        }
        
    }

}
