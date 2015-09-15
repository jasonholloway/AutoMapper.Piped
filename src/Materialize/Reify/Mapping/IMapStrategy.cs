using Materialize.Reify.Modifiers;
using System;

namespace Materialize.Reify.Mapping
{
    internal interface IMapStrategy 
    {
        Type SourceType { get; }
        Type FetchedType { get; }
        Type TransformedType { get; }

        bool FetchesToTuple { get; }
        bool RewritesExpression { get; }

        IModifier CreateModifier();
    }

}
