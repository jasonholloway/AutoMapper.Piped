using System;

namespace Materialize
{
    interface IReifyStrategy
    {
        Type SourceType { get; }
        Type ProjectedType { get; }
        Type TransformedType { get; }

        bool UsesIntermediateType { get; }

        IReifier CreateReifier();
    }

    interface IReifyStrategy<TOrig, TDest>
        : IReifyStrategy
    {
        new IReifier<TOrig, TDest> CreateReifier();
    }
    
}
