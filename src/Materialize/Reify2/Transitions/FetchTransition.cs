using Materialize.SourceRegimes;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Materialize.Reify2.Transitions
{
    class FetchTransition : Transition
    {
        public FetchTransition(ISourceRegime outRegime) 
        {
            OutRegime = outRegime;
        }


        public override string ToString() {
            return $"Fetch";
        }

    }
    

}
