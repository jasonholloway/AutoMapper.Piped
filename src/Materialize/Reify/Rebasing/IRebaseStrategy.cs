using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Materialize.Reify.Rebasing
{
    interface IRebaseStrategy
    {
        bool IsPassive { get; }
        RebaseMap ActiveMap { get; }

        RootedExpression Rebase(RootedExpression subject);
    }
}
