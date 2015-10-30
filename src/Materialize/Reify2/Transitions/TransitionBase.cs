using System;
using System.Collections.Generic;
using System.Linq;
using Materialize.SourceRegimes;

namespace Materialize.Reify2.Transitions
{
    abstract class TransitionBase : ITransition
    {
        public TransitionType TransitionType { get; protected set; }
        public ISourceRegime OutRegime { get; protected set; }        
        

        public TransitionBase(TransitionType elementType) {
            TransitionType = elementType;
        }
                
        public ITransition Rebase(ITransition element) {
            return null; //defaults to refusal: acceptance of special cases requires overrides            
        }




        public LinkedListNode<ITransition> Site { get; set; }

        public ITransition Previous {
            get { return Site.Previous?.Value; }
        }

        public ITransition Next {
            get { return Site.Next?.Value; }
        }



    }
}
