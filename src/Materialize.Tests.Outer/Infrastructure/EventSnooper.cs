using Materialize.Reify2;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Materialize.Tests.Infrastructure
{
    class EventSnooper : ISnooper
    {
        public event Action<Expression> QueryFromClient;
        public event Action<IQueryable> QueryToServer;
        public event Action<object> Fetched;
        public event Action<object> Transformed;
                        
        void ISnooper.OnQuery(Expression exQuery) {
            if(QueryFromClient != null) {
                QueryFromClient(exQuery);
            }
        }

        void ISnooper.OnStrategized(IReifyStrategy strategy) {
            //...
        }
        
        void ISnooper.OnFetch(Expression exQuery) {
            //...
        }

        void ISnooper.OnFetched(object fetched) {
            if(Fetched != null) {
                Fetched(fetched);
            }
        }

        void ISnooper.OnTransformed(object transformed) {
            if(Transformed != null) {
                Transformed(transformed);
            }
        }

        public void OnTransform(Expression exTransform) {
            //...
        }
    }
}
