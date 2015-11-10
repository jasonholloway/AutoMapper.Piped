using Materialize.Reify2.Transitions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Materialize.Monitor.Reporting
{
    public class TransitionGroupReport : Report
    {
        public TransitionReport[] Transitions { get; private set; }

        internal TransitionGroupReport(Guid sessionGuid, int reportID, string name, IEnumerable<Transition> trans) 
            : base(sessionGuid, reportID, name) 
        {
            Transitions = trans.Select(t => (TransitionReport)CreateTransitionReport((dynamic)t)).ToArray();
        }

        protected TransitionGroupReport() { }



        static TransitionReport CreateTransitionReport(Transition t) {
            return new TransitionReport(t);
        }

        static TransitionReport CreateTransitionReport(SeqTransition t) {
            return new SeqTransitionReport(t);
        }

    }

}