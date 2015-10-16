using Materialize.Reify.Parsing.Methods.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Materialize.Reify.Parsing.Methods.Quantifiers
{
    class PredQuantifierParser : FilterParserBase
    {

        protected override IParseStrategy Parse() 
        {
            var predRebase = RebasePredicateToSourceType((UnaryExpression)CallExp.Arguments[1]);
            
            if(predRebase.Successful) { //prepend our quantifier to source query
                return CreateStrategy(
                            typeof(PredQuantifierOnServerStrategy<>).MakeGenericType(ElemType),
                            UpstreamStrategy,
                            predRebase.RebaseStrategy);
            }
            else if(AllowClientSideFiltering) { //apply our quantifier at end of transformation
                return CreateStrategy(
                            typeof(PredQuantifierOnClientStrategy<>).MakeGenericType(ElemType),
                            UpstreamStrategy);
            }

            throw predRebase.GetException();
        }

    }
}
