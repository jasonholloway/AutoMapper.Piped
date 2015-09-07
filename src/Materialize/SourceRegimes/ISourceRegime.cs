using System.Linq;
using System.Linq.Expressions;

namespace Materialize.SourceRegimes
{
    internal interface ISourceRegime
    {
        bool MatchesProvider(IQueryProvider provider);
        bool Accepts(Expression exp);
    }
}
