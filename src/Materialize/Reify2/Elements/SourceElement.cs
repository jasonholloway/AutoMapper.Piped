using Materialize.SourceRegimes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Materialize.Reify2.Elements
{
    abstract class SourceElement : ElementBase
    {
        public SourceElement()
            : base(ElementType.Source) { }
    }


    class SourceElement<TElem> : SourceElement
    {        
        public SourceElement(ISourceRegime regime) {            
            OutRegime = regime;
            OutType = typeof(IQueryable<TElem>);
        }
        
    }
}
