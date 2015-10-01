using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Materialize.Reify.Rebasing2;
using System.Reflection;

namespace Materialize.Reify.Mapping.PropertyMaps
{
    class SimplePropMapStrategy<TOrig, TDest>
        : StrategyBase<TOrig, TDest>
    {
        MapContext _ctx;
        PropMapSpec[] _propMapSpecs;


        public SimplePropMapStrategy(
            MapContext ctx, 
            TypeMap typeMap, 
            PropMapSpec[] propMapSpecs) 
        {
            _ctx = ctx;
            _propMapSpecs = propMapSpecs;
        }


        public override Type FetchType {
            get { return typeof(TDest); }
        }
        

        public override IModifier CreateModifier() {
            return new Mapper(_ctx, _propMapSpecs);
        }



        class Mapper : MapperModifier<TOrig, TDest, TDest>
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







        public override IRebaseStrategy GetRootRebaseStrategy(RootVector roots) 
        {
            if(roots.TypeVector.Equals(new TypeVector(typeof(TDest), typeof(TOrig)))) {
                return new PropMapRootRebaseStrategy(this, roots);
            }

            throw new NotImplementedException();
        }


        class PropMapRootRebaseStrategy 
            : RootRebaseStrategy<TDest, TOrig>
        {
            SimplePropMapStrategy<TOrig, TDest> _mapStrategy;
            RootVector _roots;
            IReadOnlyDictionary<MemberInfo, PropMapSpec> _dPropSpecsByDestMember;


            public PropMapRootRebaseStrategy(
                SimplePropMapStrategy<TOrig, TDest> mapStrategy, 
                RootVector roots)
            {
                _mapStrategy = mapStrategy;
                _roots = roots;

                _dPropSpecsByDestMember = _mapStrategy._propMapSpecs
                                                            .ToDictionary(s => s.PropMap.DestinationProperty.MemberInfo);
            }
            

            public override IRebaseStrategy GetRootStrategy(RootVector roots) {
                return _mapStrategy.GetRootRebaseStrategy(roots);
            }

            public override Expression Rebase(Expression exSubject) {
                return _roots.RebasedRoot;
            }

            public override IRebaseStrategy Expand(Expression exSubject) 
            {                
                var exMember = exSubject as MemberExpression;
                
                if(exMember != null
                    && exMember.Expression == _roots.OrigRoot) 
                {
                    PropMapSpec propSpec;

                    if(_dPropSpecsByDestMember.TryGetValue(exMember.Member, out propSpec)) 
                    {
                        var exRebased = Expression.MakeMemberAccess(
                                                        _roots.RebasedRoot,
                                                        propSpec.PropMap.SourceMember);

                        return propSpec.Strategy.GetRootRebaseStrategy(
                                                        new RootVector(exSubject, exRebased));
                    }
                }

                return null;
            }

        }


    }

}
