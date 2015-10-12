using Materialize.Demo2.QueryInfo;
using Materialize.Demo2.Reporting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Materialize.Demo2.Client
{
    public class SnooperFactory
    {
        ReportRelay _relay = new ReportRelay();
        
        public ISnooper CreateSnooper() {
            return new Snooper(_relay);
        }

    }
}
