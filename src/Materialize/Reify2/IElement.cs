using Materialize.SourceRegimes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Materialize.Reify2
{
    interface IElement
    {
        ElementType ElementType { get; }        
        ISourceRegime OutRegime { get; } 
        Type OutType { get; }
    }



    [Flags]
    internal enum ElementType
    {
        Source,
        Filter,
        Projector,
        Aggregator,
        RegimeBoundary
    }

}
