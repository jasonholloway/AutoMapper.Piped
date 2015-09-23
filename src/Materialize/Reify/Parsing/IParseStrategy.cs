using Materialize.Reify.Rebasing2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Materialize.Reify.Parsing
{
    interface IParseStrategy
    {        
        Type SourceType { get; }
        Type FetchType { get; }
        Type DestType { get; }

        bool FiltersFetchedSet { get; } //affects downstream possibilities...
        
        IRebaseStrategy GetRebaseStrategy(RootedExpression subject);
        
        IModifier Parse(Expression exSubject);        
    }
}
