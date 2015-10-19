using Materialize.Demo2.QueryInfo;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Reactive.Subjects;

namespace Materialize.Demo2.Reporting
{
    public class ReportRegistry
    {
        IDSource _idSource = new IDSource();
        ConcurrentDictionary<int, QueryReport> _dReports = new ConcurrentDictionary<int, QueryReport>();

        Subject<QueryReport> _addedReports = new Subject<QueryReport>();
        

        public void Add(QueryReport report) 
        {
            if(report.ReportID == null) {
                report = new QueryReport(
                                _idSource.GetNextID(),
                                report.QueryFromClient,
                                report.FetchExpression,
                                report.TransformExpression,
                                report.StrategyTree);
            }
            
            _dReports[(int)report.ReportID] = report;
            _addedReports.OnNext(report);
        }


        public QueryReport GetReport(int queryID) {
            return _dReports[queryID];
        }


        public IObservable<QueryReport> AddedReports {
            get { return _addedReports.Synchronize(); }
        }

    }
}