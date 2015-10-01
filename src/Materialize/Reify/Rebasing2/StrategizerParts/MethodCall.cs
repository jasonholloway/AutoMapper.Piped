using Materialize.Info;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Materialize.Reify.Rebasing2
{
    partial class RebaseStrategizer 
    {
        protected override IRebaseStrategy VisitMethodCall(MethodCallExpression exCall) 
        {
            if(exCall.Method.IsGenericMethod
                && exCall.Method.DeclaringType == typeof(Queryable))
            {
                var methodDef = exCall.Method.GetGenericMethodDefinition();

                if(methodDef == QueryableMethods.WhereDef) 
                {
                    var upstreamStrategy = Visit(exCall.Arguments[0]);
                    

                    var tRebasedElem = upstreamStrategy.TypeVector
                                                            .DestType.GetEnumerableElementType();

                    var mRebasedWhere = QueryableMethods.WhereDef
                                                        .MakeGenericMethod(tRebasedElem);


                    var exPred = (LambdaExpression)((UnaryExpression)exCall.Arguments[1]).Operand;
                    
                    var predRoots = new RootVector(
                                            exPred.Parameters.Single(),
                                            Expression.Parameter(tRebasedElem));

                    IRebaseStrategy predBodyStrategy = null;

                    var predRootStrategy = upstreamStrategy.GetRootStrategy(predRoots);

                    if(predRootStrategy != null) {
                        var predBodyStrategizer = SpawnStrategizer(x => {
                                x.AddRootStrategy(predRoots.OrigRoot, predRootStrategy);
                        });

                        predBodyStrategy = predBodyStrategizer.Strategize(exPred.Body);
                    }
                    else {
                        predBodyStrategy = PassiveStrategy(exPred.Body.Type);
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
                                                                        (ParameterExpression)predRoots.RebasedRoot
                                                                        ))
                                                            );
                                });                    
                }                
            }

            throw new NotImplementedException("Unhandled MethodCallExpression!");
        }
    }
}
