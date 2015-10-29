using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Materialize.SourceRegimes;

namespace Materialize.Reify2.Operations
{
    abstract class OpBase : IOperation
    {
        public OpType OpType { get; protected set; }
        public ISourceRegime OutRegime { get; protected set; }        
        public Type OutType { get; protected set; }
        

        public OpBase(OpType elementType) {
            OpType = elementType;
        }
                
        public IOperation Rebase(IOperation element) {
            return null; //defaults to refusal: acceptance of special cases requires overrides            
        }




        public LinkedListNode<IOperation> Site { get; set; }

        public IOperation Previous {
            get { return Site.Previous?.Value; }
        }

        public IOperation Next {
            get { return Site.Next?.Value; }
        }



    }
}
