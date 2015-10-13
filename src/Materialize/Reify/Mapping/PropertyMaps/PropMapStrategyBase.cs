using Materialize.Reify.Rebasing;
using Materialize.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace Materialize.Reify.Mapping.PropertyMaps
{

    abstract class PropMapStrategyBase<TOrig, TDest>
        : MapStrategyBase<TOrig, TDest>
    {

        protected PropMapSpec[] _propMapSpecs;
        

        public PropMapStrategyBase(PropMapSpec[] propMapSpecs) {
            _propMapSpecs = propMapSpecs;
        }


        public override IEnumerable<IReifyStrategy> UpstreamStrategies {
            get { return _propMapSpecs.Select(s => (IReifyStrategy)s.Strategy); }
        }


        public override IRebaseStrategy GetRootRebaseStrategy(RootVector roots) {
            if(roots.TypeVector.Equals(new TypeVector(typeof(TDest), typeof(TOrig)))) {
                return new PropMapRootRebaseStrategy(this, roots);
            }

            throw new NotImplementedException();
        }


        class PropMapRootRebaseStrategy
            : RootRebaseStrategy<TDest, TOrig>
        {
            PropMapStrategyBase<TOrig, TDest> _mapStrategy;
            RootVector _roots;
            IReadOnlyDictionary<MemberInfo, PropMapSpec> _dPropSpecsByDestMember;


            public PropMapRootRebaseStrategy(
                PropMapStrategyBase<TOrig, TDest> mapStrategy,
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

                    if(_dPropSpecsByDestMember.TryGetValue(exMember.Member, out propSpec)) {
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
