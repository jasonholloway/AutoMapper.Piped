using Materialize.SourceRegimes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Materialize.Reify2
{
    interface IOperation
    {
        OpType OpType { get; }        
        ISourceRegime OutRegime { get; } 
        Type OutType { get; }
        
        IOperation Previous { get; }
        IOperation Next { get; }
        LinkedListNode<IOperation> Site { get; set; }
    }



    [Flags]
    internal enum OpType
    {
        Source,
        Filter,
        Projector,
        Aggregator,
        RegimeBoundary
    }

}
