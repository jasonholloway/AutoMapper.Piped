using System.Linq;

namespace Materialize.SourceContexts
{
    class SourceContextDetector
    {
        ISourceContext[] _regimes = new ISourceContext[] {
                                            new EnumerableQueryContext(),
                                            new EF6Context(),
                                            new MinimalContext()
                                        };
        
        public ISourceContext DetectRegime(IQueryProvider queryProv) {
            return _regimes
                    .First(f => f.MatchesProvider(queryProv));
        }
    }
}
