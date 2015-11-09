using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Subjects;
using System.Reactive.Linq;
using Materialize.Monitor.Reporting;

namespace Materialize.Monitor.QueryInfo
{
    public class SnooperSource : IDisposable
    {
        Subject<Report> _returnedReports = new Subject<Report>();

                        
        public ISnooper GetNewSnooper() {                                    
            return new Snooper(_returnedReports);
        }
        
        public IObservable<Report> ReturnedReports {
            get { return _returnedReports.Synchronize(); }
        }
        

        public void Dispose() {
            _returnedReports.Dispose();
        }
    }


}