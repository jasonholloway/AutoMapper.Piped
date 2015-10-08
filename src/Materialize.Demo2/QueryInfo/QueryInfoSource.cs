using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Subjects;
using System.Collections.Concurrent;

namespace Materialize.Demo2.QueryInfo
{
    public class QueryInfoSource : IDisposable
    {
        int _nextQueryID = 1;
        object _sync = new object();

        ISubject<IQueryInfo> _queryReceived = new Subject<IQueryInfo>();
        ConcurrentDictionary<int, IQueryInfo> _dQueries = new ConcurrentDictionary<int, IQueryInfo>();

        
        public ISnooper GetNewSnooper() {
            int nextQueryID;

            lock(_sync) {
                nextQueryID = _nextQueryID++;
            }

            return new QuerySnooper(
                            nextQueryID,
                            qi => {
                                _dQueries[qi.QueryID] = qi;                                
                                _queryReceived.OnNext(qi);
                            });                
        }
        
        public IObservable<IQueryInfo> QueryReceived {
            get { return _queryReceived; }
        }

        internal IQueryInfo GetQueryInfo(int queryID) {
            return _dQueries[queryID];
        }

        public void Dispose() {
            _queryReceived.OnCompleted();
        }
    }


}