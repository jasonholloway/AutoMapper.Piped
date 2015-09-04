using System.Linq;
using System.Linq.Expressions;

namespace Materialize.SourceContexts
{
    internal interface ISourceContext
    {
        bool MatchesProvider(IQueryProvider provider);
        bool Accepts(Expression exp);
    }
}
