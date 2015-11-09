using System;
using System.Collections.Generic;
using System.Linq;
using Materialize.SourceRegimes;

namespace Materialize.Reify2.Transitions
{
    abstract class Transition : ITransition
    {
        public ISourceRegime OutRegime { get; protected set; }        


        public LinkedListNode<Transition> Site { get; set; }

        public Transition Previous {
            get { return Site.Previous?.Value; }
        }

        public Transition Next {
            get { return Site.Next?.Value; }
        }
        
    }
}
