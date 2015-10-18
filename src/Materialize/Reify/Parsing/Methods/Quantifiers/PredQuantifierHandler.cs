using Materialize.Reify.Parsing.Methods.Filters;
using Materialize.Reify.Rebasing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Materialize.Reify.Parsing.Methods.Quantifiers
{
    class PredQuantifierParser : FilterParserBase
    {

        protected override IParseStrategy Strategize() 
        {
            if(UpstreamStrategy.FiltersFetchedSet) {
                return CreateClientStrategy();
            }
            else {
                var predRebase = RebasePredicateToSource((UnaryExpression)CallExp.Arguments[1]);

                if(predRebase.Successful) { 
                    //prepend our quantifier to source query
                    return CreateServerStrategy(predRebase.RebaseStrategy);
                }
                else if(AllowClientSideFiltering) { 
                    //apply our quantifier at end of transformation
                    return CreateClientStrategy();
                }

                throw predRebase.GetException();
            }            
        }


        IParseStrategy CreateClientStrategy() {
            return CreateStrategy(
                        typeof(PredQuantifierOnClientStrategy<,>).MakeGenericType(SourceType, ElemType),
                        UpstreamStrategy,
                        CallExp.Method);
        }


        IParseStrategy CreateServerStrategy(IRebaseStrategy rebaseStrategy) {
            return CreateStrategy(
                        typeof(PredQuantifierOnServerStrategy<,>).MakeGenericType(SourceType, ElemType),
                        UpstreamStrategy,
                        rebaseStrategy);
        }


    }
}
