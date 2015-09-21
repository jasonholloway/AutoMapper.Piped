using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Materialize.Reify.Rebasing.Misc
{
    class PassiveStrategy : IRebaseStrategy
    {
        public bool IsPassive {
            get { return true; }
        }

        public RebaseMap ActiveMap {
            get { return default(RebaseMap); }
        }

        public RootedExpression Rebase(RootedExpression subject) {
            //Not entirely sure about this behaviour...
            //Shouldn't the root at least be changed?

            return subject;
        }
    }
}
