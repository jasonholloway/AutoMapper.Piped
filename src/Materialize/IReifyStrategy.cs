using System;

namespace Materialize
{
    interface IReifyStrategy
    {
        //Type SourceType { get; }
        //Type ProjectType { get; }
        //Type ReformType { get; }

        bool UsesIntermediateType { get; }
        IReifier CreateReifier();
    }

    interface IReifyStrategy<TOrig, TDest>
        : IReifyStrategy
    {
        new IReifier<TOrig, TDest> CreateReifier();
    }
    
}
