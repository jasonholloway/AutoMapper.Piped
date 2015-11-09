using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using Materialize.Monitor.Reporting;

namespace Materialize.Monitor.SignalR
{

    public interface IReportHubClient
    {
        void AnnounceNewReport(string sessionGuid, int reportID);
    }


    public class ReportHub : Hub<IReportHubClient>
    {
        ReportRegistry _reportRegistry;

        public ReportHub(ReportRegistry reportRegistry) {
            _reportRegistry = reportRegistry;
        }

        public Report GetReport(string sessionGuid, int reportID) {
            return _reportRegistry.GetReport(Guid.Parse(sessionGuid), reportID);
        }
        
    }

}