using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Materialize.Reify.Rebasing.Root
{
    class RootStrategy : IRebaseStrategy
    {
        RebaseMap _map;
        ParameterExpression _exNewParam;

        public RootStrategy(RebaseMap map, ParameterExpression exNewParam) {
            _map = map;
            _exNewParam = exNewParam;
        }

        public bool IsPassive {
            get { return false; }
        }

        public RebaseMap ActiveMap {
            get { return _map; }
        }

        public RootedExpression Rebase(RootedExpression subject) {
            return new RootedExpression(_exNewParam, _exNewParam);
        }
    }
}
