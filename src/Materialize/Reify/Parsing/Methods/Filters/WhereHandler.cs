using Materialize.Reify.Rebasing;
using Materialize.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Materialize.Reify.Parsing.Methods.Filters
{
    class WhereHandler : RebasingHandlerBase
    {    
        protected override IParseStrategy Strategize() 
        {
            var rebased = RebasePredicateToSource((UnaryExpression)CallExp.Arguments[1]);
            
            if(rebased.Successful) {
                return CreateStrategy(                          
                            typeof(WhereOnServerStrategy<,>).MakeGenericType(SourceType, ElemType),
                            UpstreamStrategy,
                            rebased.RebaseStrategy);
            }
            else if(AllowClientSideFiltering) {
                return CreateStrategy(
                            typeof(WhereOnClientStrategy<,>).MakeGenericType(SourceType, ElemType),
                            UpstreamStrategy);
            }

            throw rebased.GetException();
        }
    }
}
