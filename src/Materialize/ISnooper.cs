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

        void OnFetch(IQueryable query);
        void OnFetch(Expression exQuery);        
        void OnFetched(IEnumerable enFetched);

        void OnTransform(Expression exTransform);
        void OnTransformed(IEnumerable enTransformed);
    }
}
