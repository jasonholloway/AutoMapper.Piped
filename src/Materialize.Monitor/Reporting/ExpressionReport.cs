using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Materialize.Monitor.Reporting
{
    internal class ExpressionReport : Report
    {
        public string ExpressionString { get; private set; }

        public ExpressionReport(Guid sessionGuid, int reportID, string name, string expressionString) 
            : base(sessionGuid, reportID, name) 
        {
            ExpressionString = expressionString;
        }
    }

}