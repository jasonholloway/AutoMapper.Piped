using Materialize.SourceRegimes;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Materialize.Reify2.Operations
{
    class FetchOp : OpBase
    {
        public FetchOp(ISourceRegime outRegime) 
            : base(OpType.RegimeBoundary) 
        {
            OutRegime = outRegime;
        }                




    }
    

}
