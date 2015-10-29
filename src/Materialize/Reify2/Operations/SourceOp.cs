using Materialize.SourceRegimes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Materialize.Reify2.Operations
{
    abstract class SourceOp : OpBase
    {
        public SourceOp()
            : base(OpType.Source) { }
    }


    class SourceOp<TElem> : SourceOp
    {        
        public SourceOp(ISourceRegime regime) {            
            OutRegime = regime;
            OutType = typeof(IQueryable<TElem>);
        }
        
    }
}
