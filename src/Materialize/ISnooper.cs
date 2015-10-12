using Materialize.Reify;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Materialize
{
    public interface ISnooper
    {
        void OnQueryFromClient(Expression exQuery);
        void OnStrategized(IReifyStrategy strategy);
        void OnQueryToServer(IQueryable query);
        void OnFetched(IEnumerable enFetched);
        void OnTransformed(IEnumerable enTransformed);
    }
}
