using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Materialize.Demo2.QueryInfo
{
    public interface IQueryInfo
    {
        int QueryID { get; }
        Expression QueryFromClient { get; }
        Expression QueryToServer { get; }
    }
}
