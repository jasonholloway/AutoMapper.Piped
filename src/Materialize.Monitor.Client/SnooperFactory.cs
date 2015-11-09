using Materialize.Monitor.QueryInfo;
using Materialize.Monitor.Reporting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Materialize.Monitor.Client
{
    public static class SnooperFactory
    {
        public static ISnooper CreateSnooper() {
            return new Snooper(new ReportRelay());
        }

    }
}
