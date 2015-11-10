using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Materialize.Reify2.Rebase.Methods
{
    interface IParentRebaser
    {
        IRebaseStrategy Visit(Expression ex);
        Rebaser SpawnNestedVisitor(Action<Rebaser.IRootStrategyRegistrar> fnRegister);
    }
}
