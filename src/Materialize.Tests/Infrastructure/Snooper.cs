using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Materialize.Tests.Infrastructure
{
    class Snooper : ISnooper
    {
        public event Action<Expression> QueryFromClient;
        public event Action<IQueryable> QueryToServer;
        public event Action<IEnumerable<object>> Fetched;
        public event Action<IEnumerable<object>> Transformed;
        
        
        void ISnooper.OnQueryFromClient(Expression exQuery) {
            if(QueryFromClient != null) {
                QueryFromClient(exQuery);
            }
        }

        void ISnooper.OnQueryToServer(IQueryable query) {
            if(QueryToServer != null) {
                QueryToServer(query);
            }
        }

        void ISnooper.OnFetched(IEnumerable enFetched) {
            if(Fetched != null) {
                Fetched(enFetched.Cast<object>());
            }
        }

        void ISnooper.OnTransformed(IEnumerable enTransformed) {
            if(Transformed != null) {
                Transformed(enTransformed.Cast<object>());
            }
        }

    }
}
