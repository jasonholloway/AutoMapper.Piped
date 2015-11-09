using Materialize.Expressions;
using Materialize.Reify2.Transitions;
using Mono.Linq.Expressions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace Materialize.Monitor.Reporting
{
    internal class SeqTransitionReport : Report
    {
        public string ExpressionString { get; private set; }

        public SeqTransitionReport(Guid sessionGuid, int reportID, string name, SeqTransition tran) 
            : base(sessionGuid, reportID, name) 
        {
            ExpressionString = tran.GetCallExpression().Simplify().ToCSharpCode();
        }
    }
    

}