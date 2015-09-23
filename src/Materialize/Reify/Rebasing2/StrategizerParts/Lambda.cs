using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Materialize.Reify.Rebasing2
{
    partial class RebaseStrategizer 
    {
        protected override IRebaseStrategy VisitLambda(LambdaExpression exLambda) 
        {
            var strBody = Visit(exLambda.Body);
            
            var rStrParams = exLambda.Parameters
                                    .Select(p => Visit(p))
                                    .Cast<IRebaseStrategy<ParameterExpression>>()
                                    .ToArray();

            if(strBody.IsActive || rStrParams.Any(s => s.IsActive)) {
                return ActiveStrategy(
                            strBody.TypeVector,
                            (LambdaExpression x) => {
                                return Expression.Lambda(
                                                    strBody.Rebase(x.Body),
                                                    rStrParams
                                                        .Zip(x.Parameters, (s, p) => s.Rebase(p))
                                                        .ToArray()
                                                    );
                            });
            }

            return PassiveStrategy(exLambda.Type);
        }
    }
}
