using Materialize.Reify.Rebasing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Materialize.Reify.Parsing
{
    interface IParseStrategy : IReifyStrategy
    {        
        Type SourceType { get; }
        Type FetchType { get; }
        Type DestType { get; }

        bool FiltersFetchedSet { get; } //affects downstream possibilities...
        
        IRebaseStrategy GetRebaseStrategy(RebaseSubject subject);
        
        IModifier Parse(Expression exSubject);        
    }
}
