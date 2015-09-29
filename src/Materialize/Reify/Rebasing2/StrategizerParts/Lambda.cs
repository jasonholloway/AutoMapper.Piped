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

            if(strBody is PassiveRebaseStrategy 
                && rStrParams.All(s => s is PassiveRebaseStrategy)) 
                {
                    return PassiveStrategy(exLambda.Type);
                }
                        
            return Strategy(
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
    }
}
