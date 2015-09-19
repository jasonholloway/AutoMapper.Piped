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
                
        IModifier Parse(Expression exSubject);
        
        Expression RebaseToSource(
                        Expression exOldRoot, 
                        Expression exNewRoot, 
                        Expression exSubject);      //allows downstream strategies to append to source query (but before other transformations)
                                                    //by rebasing predicates to suit it. Often won't be possible
                                                    //however... in which case will return null.
    }
}
