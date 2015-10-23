using Materialize.Reify2.Rebasing;
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

        IMapperWriter CreateWriter();

        IRebaseStrategy GetRootRebaseStrategy(RootVector roots);
    }

}
