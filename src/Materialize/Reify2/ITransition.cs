using Materialize.SourceRegimes;
using System;
using System.Collections.Generic;
using System.Linq;

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
        Source = 1,
        Filter = 2,
        Projector = 4,
        Aggregator = 8,
        RegimeBoundary = 16,
        Partition = 32,
        Quantifier = 64
    }

}
