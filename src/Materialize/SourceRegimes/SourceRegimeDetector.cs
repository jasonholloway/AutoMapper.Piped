using System.Linq;

namespace Materialize.SourceRegimes
{
    class SourceRegimeDetector
    {
        ISourceRegime[] _regimes = new ISourceRegime[] {
                                            new EnumerableQueryRegime(),
                                            new EF6Regime(),
                                            new MinimalRegime()
                                        };
        
        public ISourceRegime DetectRegime(IQueryProvider queryProv) {
            return _regimes
                    .First(f => f.MatchesProvider(queryProv));
        }
    }
}
