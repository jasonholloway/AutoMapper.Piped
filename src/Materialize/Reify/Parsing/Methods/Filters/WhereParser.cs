using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Materialize.Reify.Parsing.Methods.Filters
{
    class WhereParser : FilterParserBase
    {    
        protected override IParseStrategy Parse() 
        {            
            var predRebase = RebasePredicateToSource((UnaryExpression)CallExp.Arguments[1]);
            
            if(predRebase.Successful) { //we can prepend to source query!
                return CreateStrategy(                          
                            typeof(WhereOnServerStrategy<,>).MakeGenericType(SourceType, ElemType),
                            UpstreamStrategy,
                            predRebase.RebaseStrategy);
            }
            else if(AllowClientSideFiltering) {
                return CreateStrategy(
                            typeof(WhereOnClientStrategy<,>).MakeGenericType(SourceType, ElemType),
                            UpstreamStrategy);
            }

            throw predRebase.GetException();
        }
    }
}
