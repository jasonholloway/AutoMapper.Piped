using System.Linq;
using System.Linq.Expressions;

namespace Materialize.SourceRegimes
{
    class EnumerableQueryRegime : ISourceRegime
    {
        public bool MatchesProvider(IQueryProvider provider) {
            return provider is EnumerableQuery;
        }

        public bool ServerAccepts(Expression exp) {
            return true;
        }
    }
}
