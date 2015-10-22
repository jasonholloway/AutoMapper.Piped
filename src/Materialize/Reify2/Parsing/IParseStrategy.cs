using Materialize.Reify2.Rebasing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Materialize.Reify2.Parsing
{
    interface IParseStrategy : IReifyStrategy
    {        
        Type SourceType { get; }
        Type FetchType { get; }
        Type DestType { get; }

        bool FiltersFetchedSet { get; } //affects downstream possibilities...

        IModifier Parse(Expression exSubject);

        IRebaseStrategy RebaseToSource(RebaseSubject subject);        
    }
}
