using System.Linq;

namespace Materialize.SourceRegimes
{
    public interface ISourceRegimeDetector
    {
        ISourceRegime DetectRegime(IQueryProvider queryProv);
    }
}
