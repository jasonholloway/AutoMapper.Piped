﻿using Materialize.Reify.Parsing;
using Materialize.Reify.Rebasing;
using System;

namespace Materialize.Reify.Mapping
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
