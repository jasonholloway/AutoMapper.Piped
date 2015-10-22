using Materialize.Reify2.Parsing;
using Materialize.Reify2.Rebasing;
using System;

namespace Materialize.Reify2.Mapping
{
    internal interface IMapStrategy : IReifyStrategy
    {
        Type SourceType { get; }
        Type FetchType { get; }
        Type TransformedType { get; }
        
        bool FetchesToTuple { get; }
        bool RewritesExpression { get; }

        IModifier CreateModifier();

        IRebaseStrategy GetRootRebaseStrategy(RootVector roots);
    }

}
