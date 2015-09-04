using System.Linq;
using System.Linq.Expressions;

namespace Materialize.SourceContexts
{
    class EnumerableQueryContext : ISourceContext
    {
        public bool MatchesProvider(IQueryProvider provider) {
            return provider is EnumerableQuery;
        }

        public bool Accepts(Expression exp) {
            return true;
        }
    }
}
