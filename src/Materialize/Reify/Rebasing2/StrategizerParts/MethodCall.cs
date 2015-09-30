using Materialize.Info;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Materialize.Reify.Rebasing2
{
    partial class RebaseStrategizer 
    {
        //Question of whether rooting should flow through method calls
        //Yes - as long as they are Queryable methods
        
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


                    var exQuotedPred = (UnaryExpression)exCall.Arguments[1];
                    var exPred = (LambdaExpression)exQuotedPred.Operand;


                    var predRoots = new RootVector(
                                            exPred.Parameters.Single(),
                                            Expression.Parameter(tRebasedElem));
                    
                    var predRootStrategy = upstreamStrategy.GetRootStrategy(predRoots);

                    var predStrategizer = SpawnStrategizer(x => {
                                                                if(predRootStrategy != null) {
                                                                    x.AddRootStrategy(predRoots.OrigRoot, predRootStrategy);
                                                                }
                                                            });
                    
                    var predStrategy = predStrategizer.Strategize(exQuotedPred);


                    var mRebasedWhere = QueryableMethods.WhereDef
                                                        .MakeGenericMethod(tRebasedElem);
                    
                    return RootedStrategy(
                                upstreamStrategy, 
                                (MethodCallExpression ex) => {
                                    var exRebasedInst = upstreamStrategy.Rebase(ex.Arguments[0]);
                                    var exRebasedPred = predStrategy.Rebase(ex.Arguments[1]);

                                    return Expression.Call(
                                                        mRebasedWhere,
                                                        exRebasedInst,
                                                        exRebasedPred);
                                });                    
                }                
            }

            throw new NotImplementedException("Unhandled MethodCallExpression!");
        }
    }
}
