using Materialize.Reify2;
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
        void OnQuery(Expression exQuery);

        void OnStrategized(IReifyStrategy strategy);
        
        void OnFetch(Expression exFetch);        
        void OnFetched(object fetched);

        void OnTransform(Expression exTransform);
        void OnTransformed(object transformed);
    }
}
