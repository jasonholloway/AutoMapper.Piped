using Materialize.Reify.Parsing.Methods.Filters;
using Materialize.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Materialize.Reify.Parsing.Methods.Aggregators
{
    class PredCountHandler : FilterHandlerBase
    {
        protected override IParseStrategy Strategize() 
        {
            //This is all wrong!
            //Upstream filters will mess this up as is
            //Need to check whether upstream strategies stick to one-to-one mapping (ie are there filters?)


            var predRebase = RebasePredicateToSource((UnaryExpression)CallExp.Arguments[1]);

            if(predRebase.Successful) { //prepend our quantifier to source query
                return CreateStrategy(
                            typeof(PredCountOnServerStrategy<,>).MakeGenericType(SourceType, ElemType),
                            UpstreamStrategy,
                            predRebase.RebaseStrategy);
            }
            else if(AllowClientSideFiltering) { //apply our quantifier at end of transformation
                return CreateStrategy(
                            typeof(PredCountOnClientStrategy<,>).MakeGenericType(SourceType, ElemType),
                            UpstreamStrategy);
            }

            throw predRebase.GetException();
        }
        
    }
}
