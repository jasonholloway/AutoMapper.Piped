﻿using Materialize.Reify.Parsing.Methods.Filters;
using Materialize.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Materialize.Reify.Parsing.Methods.Aggregators
{
    class PredCountParser : FilterParserBase
    {
        protected override IParseStrategy Parse() {
            var predRebase = RebasePredicateToSourceType((UnaryExpression)CallExp.Arguments[1]);

            if(predRebase.Successful) { //prepend our quantifier to source query
                return CreateStrategy(
                            typeof(PredCountOnServerStrategy<>).MakeGenericType(ElemType),
                            UpstreamStrategy,
                            predRebase.RebaseStrategy);
            }
            else if(AllowClientSideFiltering) { //apply our quantifier at end of transformation
                return CreateStrategy(
                            typeof(PredCountOnClientStrategy<>).MakeGenericType(ElemType),
                            UpstreamStrategy);
            }

            throw predRebase.GetException();
        }
        
    }
}
