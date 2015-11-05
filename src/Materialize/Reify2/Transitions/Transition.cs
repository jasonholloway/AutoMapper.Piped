using System;
using System.Collections.Generic;
using System.Linq;
using Materialize.SourceRegimes;
using Materialize.SequenceMethods;

namespace Materialize.Reify2.Transitions
{
    abstract class Transition : ITransition
    {
        public ISourceRegime OutRegime { get; protected set; }        


        public LinkedListNode<ITransition> Site { get; set; }

        public ITransition Previous {
            get { return Site.Previous?.Value; }
        }

        public ITransition Next {
            get { return Site.Next?.Value; }
        }



    }
}
