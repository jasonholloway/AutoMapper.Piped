using Materialize.Reify2.Rebase;
using System;

namespace Materialize.Reify2.Mapping
{
    internal interface IMapStrategy
    {
        Type SourceType { get; }
        Type FetchType { get; }
        Type TransformedType { get; }
        
        bool FetchesToTuple { get; }
        bool RewritesExpression { get; }

        IMapper CreateWriter();

        IRebaseStrategy GetRootRebaseStrategy(RootVector roots);
    }

}
