using System.Linq;

namespace Materialize.SourceRegimes
{
    public interface ISourceRegimeProvider
    {
        ISourceRegime GetRegime(IQueryable qySource);
    }
}
