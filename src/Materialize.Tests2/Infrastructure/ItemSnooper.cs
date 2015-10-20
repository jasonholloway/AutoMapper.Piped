using Materialize.Reify;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Materialize.Tests.Infrastructure
{
    class ItemSnooper : ISnooper
    {
        public Expression QueryExpFromClient { get; private set; }
        public IQueryable QueryToServer { get; private set; }
        public Expression FetchExpression { get; private set; }
        public Expression TransformExpression { get; private set; }
        public object[] Fetched { get; private set; }
        public object[] Transformed { get; private set; }
                        
        void ISnooper.OnQuery(Expression exQuery) {
            QueryExpFromClient = exQuery;
        }

        void ISnooper.OnStrategized(IReifyStrategy strategy) {
            //...
        }
        
        void ISnooper.OnFetch(Expression exQuery) {
            FetchExpression = exQuery;
        }

        void ISnooper.OnFetched(object fetched) {
            Fetched = ((IEnumerable)fetched).Cast<object>().ToArray();
        }

        void ISnooper.OnTransform(Expression exTransform) {
            TransformExpression = exTransform;
        }


        void ISnooper.OnTransformed(object transformed) {
            Transformed = ((IEnumerable)transformed).Cast<object>().ToArray();
        }

    }
}
