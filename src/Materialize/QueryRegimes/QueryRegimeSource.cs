using System.Linq;

namespace Materialize.QueryRegimes
{
    class QueryRegimeSource
    {
        IQueryRegime[] _filters;

        public QueryRegimeSource() {
            _filters = new IQueryRegime[] {
                new EFQueryRegime(),
                new MinimalQueryRegime()
            };
        }
        
        public IQueryRegime GetFilter(IQueryProvider queryProv) {
            return _filters.First(f => f.MatchesProvider(queryProv));
        }
    }
}
