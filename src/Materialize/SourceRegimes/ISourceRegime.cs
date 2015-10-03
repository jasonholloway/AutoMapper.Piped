using System.Linq;
using System.Linq.Expressions;

namespace Materialize.SourceRegimes
{
    public interface ISourceRegime
    {
        bool ServerAccepts(Expression exp);
    }
}
