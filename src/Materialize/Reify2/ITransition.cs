using Materialize.SourceRegimes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Materialize.Reify2
{
    interface ITransition
    {
        TransitionType TransitionType { get; }        
        ISourceRegime OutRegime { get; } 
        
        ITransition Previous { get; }
        ITransition Next { get; }
        LinkedListNode<ITransition> Site { get; set; }
    }



    [Flags]
    internal enum TransitionType
    {
        Source,
        Filter,
        Projector,
        Aggregator,
        RegimeBoundary
    }

}
