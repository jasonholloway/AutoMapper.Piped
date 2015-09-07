using Materialize.Reify.Modifiers;
using System;

namespace Materialize.Reify.Mapping
{
    interface IMapStrategy
    {
        Type SourceType { get; }
        Type ProjectedType { get; }
        Type TransformedType { get; }

        bool UsesIntermediateType { get; }

        IModifier CreateModifier();
    }

}
