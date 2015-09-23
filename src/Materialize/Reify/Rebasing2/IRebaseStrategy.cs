using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Materialize.Reify.Rebasing2
{
    interface IRebaseStrategy
    {
        bool IsActive { get; }
        bool IsRooted { get; }
        TypeVector TypeVector { get; }
        IReadOnlyDictionary<ParameterExpression, ParameterExpression> Roots { get; }
        
        Expression Rebase(Expression exSubject);
    }


    interface IRebaseStrategy<TExp> : IRebaseStrategy 
        where TExp : Expression
    {
        TExp Rebase(TExp exSubject);
    }


}
