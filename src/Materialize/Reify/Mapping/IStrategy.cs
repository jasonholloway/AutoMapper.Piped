using Materialize.Reify.Mods;
using System;

namespace Materialize.Reify.Mapping
{
    interface IStrategy
    {
        Type SourceType { get; }
        Type ProjectedType { get; }
        Type TransformedType { get; }

        bool UsesIntermediateType { get; }

        IModifier CreateModifier();
    }

}
