using System.Linq;
using System.Linq.Expressions;

namespace Materialize.QueryRegimes
{
    internal interface IQueryRegime
    {
        bool MatchesProvider(IQueryProvider provider);
        bool Accepts(Expression exp);
    }
}
