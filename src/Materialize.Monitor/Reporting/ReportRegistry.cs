using Materialize.Monitor.QueryInfo;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Reactive.Subjects;

namespace Materialize.Monitor.Reporting
{
    public class ReportRegistry
    {
        ConcurrentDictionary<Guid, ConcurrentDictionary<int, Report>> _dSessions 
            = new ConcurrentDictionary<Guid, ConcurrentDictionary<int, Report>>();

        Subject<Report> _addedReports = new Subject<Report>();
        

        public void Add(Report report) 
        {
            var dReports = _dSessions.GetOrAdd(report.SessionGuid, g => new ConcurrentDictionary<int, Report>());
            dReports[report.ReportID] = report; 
            
            _addedReports.OnNext(report);
        }


        public Report GetReport(Guid sessionGuid, int reportID) {
            return _dSessions[sessionGuid][reportID];
        }


        public IObservable<Report> AddedReports {
            get { return _addedReports.Synchronize(); }
        }

    }
}