using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using Materialize.Demo2.Reporting;

namespace Materialize.Demo2.SignalR
{

    public interface IReportHubClient
    {
        void AnnounceNewReport(int reportID);
    }


    public class ReportHub : Hub<IReportHubClient>
    {
        ReportRegistry _reportRegistry;

        public ReportHub(ReportRegistry reportRegistry) {
            _reportRegistry = reportRegistry;
        }

        public QueryReport GetReport(int reportID) {
            return _reportRegistry.GetReport(reportID);
        }
        
    }

}