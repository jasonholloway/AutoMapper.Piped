using System.Linq;
using System.Linq.Expressions;

namespace Materialize.SourceRegimes
{
    public interface ISourceRegime
    {
        bool MatchesProvider(IQueryProvider provider);
        bool ServerAccepts(Expression exp);
    }
}
