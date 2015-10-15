using Materialize.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Materialize.Reify.Rebasing
{
    partial class RebaseStrategizer
    {
        [Obsolete]
        IRebaseStrategy QueryableWhere(MethodCallExpression exCall) 
        {
            var upstreamStrategy = Visit(exCall.Arguments[0]);
            

            var tRebasedElem = upstreamStrategy.TypeVector
                                                    .DestType.GetEnumerableElementType();

            var mRebasedWhere = QueryableMethods.Where
                                                .MakeGenericMethod(tRebasedElem);


            var exPred = (LambdaExpression)((UnaryExpression)exCall.Arguments[1]).Operand;

            var predRoots = new RootVector(
                                    exPred.Parameters.Single(),
                                    Expression.Parameter(tRebasedElem));


            IRebaseStrategy predBodyStrategy = null;
            ParameterExpression exRebasedPredParam = null;

            var predRootStrategy = upstreamStrategy.GetRootStrategy(predRoots);

            if(predRootStrategy != null) {
                var predBodyStrategizer = SpawnNestedStrategizer(x => {
                    x.AddRootStrategy(predRoots.OrigRoot, predRootStrategy);
                });

                predBodyStrategy = predBodyStrategizer.Strategize(exPred.Body);
                exRebasedPredParam = (ParameterExpression)predRoots.RebasedRoot;
            }
            else {
                predBodyStrategy = PassiveStrategy(exPred.Body.Type);
                exRebasedPredParam = (ParameterExpression)predRoots.OrigRoot;
            }


            return RootedStrategy(
                        upstreamStrategy,
                        (MethodCallExpression ex) => {
                            var exRebasedInst = upstreamStrategy.Rebase(ex.Arguments[0]);

                            var exPredBody = ((LambdaExpression)((UnaryExpression)ex.Arguments[1]).Operand).Body;
                            var exRebasedPredBody = predBodyStrategy.Rebase(exPredBody);

                            return Expression.Call(
                                                mRebasedWhere,
                                                exRebasedInst,
                                                Expression.Quote(
                                                    Expression.Lambda(
                                                                exRebasedPredBody,
                                                                exRebasedPredParam
                                                                ))
                                                    );
                        });

        }
    }
}
