using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Materialize.SourceRegimes;

namespace Materialize.Reify2.Elements
{
    abstract class ElementBase : IElement
    {
        public ElementType ElementType { get; protected set; }
        public ISourceRegime OutRegime { get; protected set; }        
        public Type OutType { get; protected set; }

        public ElementBase(ElementType elementType) {
            ElementType = elementType;
        }
                
        public IElement Rebase(IElement element) {
            return null; //defaults to refusal: acceptance of special cases requires overrides
        }

                
    }
}
