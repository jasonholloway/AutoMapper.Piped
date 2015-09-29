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
    }


    interface IRebaseStrategy<TExp> : IRebaseStrategy 
        where TExp : Expression
    {
        TExp Rebase(TExp exSubject);
    }


}
