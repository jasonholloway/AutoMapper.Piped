using Materialize.Monitor.Reporting;
using Nancy;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Materialize.Monitor.NancyModules
{
    public class MainModule : NancyModule
    {
        public MainModule(ReportRegistry reportRegistry) 
        {
            Get[""] = _ => View["Index.cshtml"];

            Get[@"/report/(?<sessionGuid>[A-Za-z0-9\-]+)/(?<reportID>[\d+])"] 
                = p => {
                    var v = View["Report.cshtml", reportRegistry.GetReport(Guid.Parse(p.sessionGuid), p.reportID)];
                    return v;
                };
        }
    }
}