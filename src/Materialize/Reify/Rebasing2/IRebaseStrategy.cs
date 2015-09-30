using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Materialize.Reify.Rebasing2
{
    interface IRebaseStrategy
    {
        TypeVector TypeVector { get; }        
        Expression Rebase(Expression exSubject);
        IRebaseStrategy Expand(Expression exSubject);
        IRebaseStrategy GetRootStrategy(RootVector roots);
    }


    interface IRebaseStrategy<TExp> : IRebaseStrategy 
        where TExp : Expression
    {
        TExp Rebase(TExp exSubject);
    }


}
