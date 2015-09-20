using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Materialize.Reify.Rebasing
{
    class RebaserFactory
    {
        IRebaseStrategySource _rebaseStrategies;

        public RebaserFactory(IRebaseStrategySource rebaseStrategies) {
            _rebaseStrategies = rebaseStrategies;
        }

        public Rebaser Create(RebaseMap rebaseMap) {
            return new Rebaser(_rebaseStrategies, rebaseMap);
        }

    }
}
