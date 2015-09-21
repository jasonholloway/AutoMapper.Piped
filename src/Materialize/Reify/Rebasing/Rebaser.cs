using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Materialize.Reify.Rebasing
{
    class Rebaser
    {
        IRebaseStrategySource _rebaseStrategies;
        RebaseMap _rebaseMap;

        public Rebaser(IRebaseStrategySource rebaseStrategies, RebaseMap rebaseMap) {
            _rebaseStrategies = rebaseStrategies;
            _rebaseMap = rebaseMap;
        }

        public RootedExpression Rebase(RootedExpression subject) 
        {            
            var exNewRoot = Expression.Parameter(_rebaseMap.RebasedType, "rebased");

            var ctx = new RebaseContext(
                                    subject,
                                    exNewRoot,
                                    _rebaseMap);
            
            var strategy = _rebaseStrategies.GetStrategy(ctx);

            return strategy.Rebase(subject);
        }

    }
}
