using Materialize.SourceRegimes;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Materialize.Reify2.Transitions
{
    class FetchTransition : TransitionBase
    {
        public FetchTransition(ISourceRegime outRegime) 
            : base(TransitionType.RegimeBoundary) 
        {
            OutRegime = outRegime;
        }


        public override string ToString() {
            return $"Fetch";
        }

    }
    

}
