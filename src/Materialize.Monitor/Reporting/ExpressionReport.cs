using Materialize.Expressions;
using Mono.Linq.Expressions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace Materialize.Monitor.Reporting
{
    public class ExpressionReport : Report
    {
        public string ExpressionString { get; private set; }
        
        internal ExpressionReport(Guid sessionGuid, int reportID, string name, Expression ex) 
            : base(sessionGuid, reportID, name) 
        {
            ExpressionString = ex.Simplify().ToCSharpCode();            
        }

        protected ExpressionReport() { }

    }

}