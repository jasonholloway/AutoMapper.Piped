using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace Materialize.Demo2.QueryInfo
{
    class QuerySnooper : ISnooper, IQueryInfo
    {
        Action<IQueryInfo> _fnSink;

        public int QueryID { get; private set; }
        public Expression QueryFromClient { get; private set; }
        public Expression QueryToServer { get; private set; }

        public QuerySnooper(int queryID, Action<IQueryInfo> fnSink) {
            QueryID = queryID;
            _fnSink = fnSink;
        }

        public void OnQueryFromClient(Expression exQuery) {
            QueryFromClient = exQuery;
        }

        public void OnQueryToServer(IQueryable query) {
            QueryToServer = query.Expression;
        }

        public void OnFetched(IEnumerable enFetched) {
            //...
        }

        public void OnTransformed(IEnumerable enTransformed) {
            //...

            _fnSink(this);
        }
    }
}