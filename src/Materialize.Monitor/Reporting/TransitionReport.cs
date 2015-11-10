using Materialize.Reify2.Transitions;
using Materialize.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Materialize.Monitor.Reporting
{
    public class TransitionReport
    {
        public string Name { get; private set; }

        internal TransitionReport(Transition tran)
        {
            Name = tran.GetType().GetNiceName();
        }

        protected TransitionReport() { }

    }

}