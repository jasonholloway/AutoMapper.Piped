using System;
using System.Linq.Expressions;

namespace Materialize.Reify2
{
    interface IModifier
    {
        Expression ServerFilter(Expression exQuery);
        Expression ServerProject(Expression exQuery);                
        Expression ClientTransform(Expression exTransform);        
    }
}
