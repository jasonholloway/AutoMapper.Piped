using Materialize.Demo2.Reporting;
using Nancy;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Materialize.Demo2.NancyModules
{
    public class MainModule : NancyModule
    {
        public MainModule(ReportRegistry reportRegistry) 
        {
            Get[""] = _ => View["Index.cshtml"];

            Get[@"/report/(?<id>\d+)"] = p => {
                var v = View["Report.cshtml", reportRegistry.GetReport(p.id)];
                return v;
            };
        }
    }
}