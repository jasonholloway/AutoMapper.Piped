using Materialize.Reify2.Transitions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Materialize.Monitor.Reporting
{
    internal class TransitionReport : Report
    {
        //...

        public TransitionReport(Guid sessionGuid, int reportID, string name, Transition tran) 
            : base(sessionGuid, reportID, name) 
        {
            //...
        }
    }

}