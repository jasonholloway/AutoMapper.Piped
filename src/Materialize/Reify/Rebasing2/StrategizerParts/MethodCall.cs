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
                    var strInst = Visit(exCall.Arguments[0]);

                    if(strInst.IsActive) {                        
                        var tRebasedElem = strInst.TypeVector.DestType
                                                                .GetEnumerableElementType();

                        var exQuotedPred = (UnaryExpression)exCall.Arguments[1];

                        var exPred = (LambdaExpression)exQuotedPred.Operand;

                        var predStrategizer = new RebaseStrategizer(
                                                            this,
                                                            x => {
                                                                x.AddRoot(
                                                                    exPred.Parameters.Single(),
                                                                    Expression.Parameter(tRebasedElem));   
                                                            });

                        var strPred = predStrategizer.GetStrategy(exQuotedPred);


                        var mRebasedWhere = QueryableMethods.WhereDef
                                                            .MakeGenericMethod(tRebasedElem);

                        Func<MethodCallExpression, MethodCallExpression> fnRebaser;
                        
                        fnRebaser = (x) => {
                            var exRebasedInst = strInst.Rebase(x.Arguments[0]);
                            var exRebasedPred = strPred.Rebase(x.Arguments[1]);

                            return Expression.Call(
                                                mRebasedWhere,
                                                exRebasedInst,
                                                exRebasedPred);
                        };

                        return strInst.IsRooted
                                ? RootedStrategy(strInst.TypeVector, fnRebaser)
                                : ActiveStrategy(strInst.TypeVector, fnRebaser);
                    }
                }
            }

            return PassiveStrategy(exCall.Type);            
        }
    }
}
