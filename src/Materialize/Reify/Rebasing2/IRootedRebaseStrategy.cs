using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Materialize.Reify.Rebasing2
{
    interface IRootedRebaseStrategy : IRebaseStrategy 
    {
        IRebaseStrategy Expand(Expression exSubject);
    }

    interface IRootedRebaseStrategy<TExp> : IRootedRebaseStrategy, IRebaseStrategy<TExp>
        where TExp : Expression
    {
    }

}
