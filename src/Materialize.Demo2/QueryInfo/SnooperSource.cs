using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Subjects;
using System.Reactive.Linq;
using Materialize.Demo2.Reporting;

namespace Materialize.Demo2.QueryInfo
{
    public class SnooperSource : IDisposable
    {
        Subject<QueryReport> _returnedReports = new Subject<QueryReport>();

                        
        public ISnooper GetNewSnooper() {                                    
            return new Snooper(_returnedReports);
        }
        
        public IObservable<QueryReport> ReturnedReports {
            get { return _returnedReports.Synchronize(); }
        }
        

        public void Dispose() {
            _returnedReports.Dispose();
        }
    }


}