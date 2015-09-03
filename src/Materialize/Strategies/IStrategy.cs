using System;

namespace Materialize.Strategies
{
    interface IStrategy
    {
        Type SourceType { get; }
        Type ProjectedType { get; }
        Type TransformedType { get; }

        bool UsesIntermediateType { get; }

        IReifier CreateReifier();
    }

    interface IStrategy<TOrig, TDest>
        : IStrategy
    {
        new IReifier<TOrig, TDest> CreateReifier();
    }
    
}
