using Materialize.Reify.Parsing;
using Materialize.Reify.Rebasing2;
using System;

namespace Materialize.Reify.Mapping
{
    internal interface IMapStrategy 
    {
        Type SourceType { get; }
        Type FetchType { get; }
        Type TransformedType { get; }
        
        bool FetchesToTuple { get; }
        bool RewritesExpression { get; }

        IModifier CreateModifier();        
    }

}
