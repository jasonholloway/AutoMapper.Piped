using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Materialize.Reify.Rebasing2
{
    partial class Rebaser 
    {
        protected override Rebased VisitLambda(LambdaExpression lambda) 
        {   
            var exBody = Visit(lambda.Body).Expression;

            var rexParams = lambda.Parameters
                                    .Select(p => (ParameterExpression)Visit(p).Expression)
                                    .ToArray();

            return Rebased.Passive(
                            Expression.Lambda(exBody, rexParams)
                            );
        }
    }
}
