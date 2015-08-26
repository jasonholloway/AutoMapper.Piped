using System.Linq.Expressions;

namespace Materialize
{
    interface IReifier
    {
        Expression VisitExpression(Expression exOrig);
        object VisitFetchedNode(object orig);
    }

    interface IReifier<TOrig, TDest>
        : IReifier
    {

    }
}
