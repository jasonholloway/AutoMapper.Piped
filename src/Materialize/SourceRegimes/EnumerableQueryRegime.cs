using System;
using System.Linq;
using System.Linq.Expressions;

namespace Materialize.SourceRegimes
{
    class EnumerableQueryRegimeProvider : ISourceRegimeProvider
    {
        public ISourceRegime GetRegime(IQueryable qySource) {
            return qySource is EnumerableQuery
                    ? new EnumerableQueryRegime()
                    : null;
        }
    }
       

    class EnumerableQueryRegime : ISourceRegime
    {
        public bool ServerAccepts(Expression exp) {
            return true;
        }
    }
}
