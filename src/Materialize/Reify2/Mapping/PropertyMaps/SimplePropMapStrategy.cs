using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Materialize.Reify2.Rebasing;
using System.Reflection;
using Materialize.Types;

namespace Materialize.Reify2.Mapping.PropertyMaps
{
    class SimplePropMapStrategy<TOrig, TDest>
        : PropMapStrategyBase<TOrig, TDest>
    {
        MapContext _ctx;
        

        public SimplePropMapStrategy(
            MapContext ctx, 
            TypeMap typeMap, 
            PropMapSpec[] propMapSpecs
            ) 
            : base(propMapSpecs) 
        {
            _ctx = ctx;
        }


        public override Type FetchType {
            get { return typeof(TDest); }
        }
        

        public override IMapperWriter CreateWriter() {
            return new Mapper(_ctx, _propMapSpecs);
        }



        class Mapper : MapperWriter<TOrig, TDest, TDest>
        {
            MapContext _ctx;
            IEnumerable<PropMapSpec> _propSpecs;

            public Mapper(MapContext ctx, IEnumerable<PropMapSpec> propSpecs) {
                _ctx = ctx;
                _propSpecs = propSpecs;
            }


            MemberBinding[] BuildBindings(Expression exSource) {
                return _propSpecs.Select(
                            spec => {
                                var sourceMember = spec.PropMap.SourceMember;
                                var destMember = spec.PropMap.DestinationProperty.MemberInfo;
                                var subMapper = spec.Strategy.CreateWriter(); //this should be cached in strategy...

                                var exInput = Expression.MakeMemberAccess(
                                                                    exSource,
                                                                    sourceMember);

                                var exMappedInput = subMapper.ServerRewrite(exInput);

                                return Expression.Bind(
                                                    destMember,
                                                    exMappedInput);
                            }).ToArray();
            }

            protected override Expression ServerRewrite(Expression exQuery) {
                return Expression.MemberInit( //should handle custom ctors etc.
                                    Expression.New(typeof(TDest).GetConstructors().First()),
                                    BuildBindings(exQuery)
                                    );
            }



            //protected override Expression TransformMod(Expression exFetched) {
            //    return exFetched;
            //}
            

            //protected override TDest Transform(TDest obj) {
            //    return obj;
            //}

        }

        

    }

}
