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
    public class SeqTransitionReport : TransitionReport
    {
        public string ExpressionString { get; private set; }

        internal SeqTransitionReport(SeqTransition tran)
            : base(tran)
        {
            //ExpressionString = tran..GetCallExpression().Simplify().ToCSharpCode();
        }

        protected SeqTransitionReport() { }

    }
    

}