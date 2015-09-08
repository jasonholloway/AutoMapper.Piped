using System.Linq;

namespace Materialize.SourceRegimes
{
    internal interface ISourceRegimeDetector
    {
        ISourceRegime DetectRegime(IQueryProvider queryProv);
    }
}
