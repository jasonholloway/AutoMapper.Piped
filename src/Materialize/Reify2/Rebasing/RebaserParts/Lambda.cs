using Materialize.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Materialize.Reify2.Rebasing
{
    partial class Rebaser 
    {
        protected override IRebaseStrategy VisitLambda(LambdaExpression exLambda) 
        {
            var paramStrats = exLambda.Parameters.Select(p => Visit(p));
            var bodyStrat = Visit(exLambda.Body);
            
            return UnrootedStrategy(
                        new TypeVector(typeof(object), typeof(object)), //think this will work fine
                        (LambdaExpression x) => {
                            return Expression.Lambda(
                                        bodyStrat.Rebase(x.Body),
                                        paramStrats
                                                .Zip(x.Parameters, (s, p) => s.Rebase(p))
                                                .Cast<ParameterExpression>()
                                                .ToArray()
                                        );
                        });
        }
    }
}
