using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Materialize.Reify.Rebasing
{
    interface IRebaseRule
    {
        IRebaseStrategy GetStrategy(RebaseContext ctx);
    }
}
