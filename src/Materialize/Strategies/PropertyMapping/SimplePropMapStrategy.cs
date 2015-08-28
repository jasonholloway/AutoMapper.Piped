﻿using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Materialize.Strategies.PropertyMapping
{
    class SimplePropMapStrategy<TOrig, TDest>
        : ReifierStrategy<TOrig, TDest>
    {
        ReifyContext _ctx;
        PropMapSpec[] _propSpecs;

        public SimplePropMapStrategy(ReifyContext ctx, TypeMap typeMap, PropMapSpec[] propSpecs) {
            _ctx = ctx;
            _propSpecs = propSpecs;
        }

        public override bool UsesIntermediateType {
            get { return false; }
        }

        public override IReifier<TOrig, TDest> CreateReifier() {
            return new Reifier(_ctx, _propSpecs);
        }



        class Reifier : ReifierBase<TOrig, TDest>
        {
            ReifyContext _ctx;
            PropMapSpec[] _propSpecs;

            public Reifier(ReifyContext ctx, PropMapSpec[] propSpecs) {
                _ctx = ctx;
                _propSpecs = propSpecs;
            }


            MemberBinding[] BuildBindings(Expression exSource) {
                return _propSpecs.Select(
                            spec => {
                                var sourceMember = spec.PropMap.SourceMember;
                                var destMember = spec.PropMap.DestinationProperty.MemberInfo;
                                var subReifier = spec.Strategy.CreateReifier();

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


            protected override TDest ReformSingle(TDest obj) {
                throw new NotImplementedException();
            }

        }
        
    }

}
