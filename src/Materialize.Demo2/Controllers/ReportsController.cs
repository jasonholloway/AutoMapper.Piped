using Materialize.Demo2.Reporting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Materialize.Demo2.Controllers
{
    [RoutePrefix("api/reports")]
    public class ReportsController : ApiController
    {
        ReportRegistry _registry;

        public ReportsController(ReportRegistry registry) {
            _registry = registry;
        }

        [HttpPost]
        [Route("submit")]
        public void Submit(QueryReport report) {
            _registry.Add(report);
        }

    }
}
