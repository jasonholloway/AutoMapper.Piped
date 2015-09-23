using Materialize.Info;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Materialize.Reify.Rebasing2
{
    partial class Rebaser 
    {
        protected override Rebased VisitMethodCall(MethodCallExpression exCall) 
        {
            if(exCall.Method.IsGenericMethod
                && exCall.Method.DeclaringType == typeof(Queryable))
            {
                var methodDef = exCall.Method.GetGenericMethodDefinition();

                if(methodDef == QueryableMethods.WhereDef) 
                {
                    var resNewInst = Visit(exCall.Arguments[0]);

                    if(resNewInst.IsRebased) {
                        var exNewUpstream = resNewInst.Expression;
                        var tNewElem = resNewInst.TypeVector.DestType.GetEnumerableElementType();


                        var exPredicate = (LambdaExpression)((UnaryExpression)exCall.Arguments[1]).Operand;

                        var predicateRebaser = new Rebaser(this);
                        predicateRebaser.Roots[exPredicate.Parameters.Single()] = Expression.Parameter(tNewElem);

                        var exNewPred = predicateRebaser
                                            .Visit(exCall.Arguments[1])
                                            .Expression;


                        return Rebased.Active(
                                        Expression.Call(
                                                    QueryableMethods.WhereDef
                                                                        .MakeGenericMethod(tNewElem),
                                                    exNewUpstream,
                                                    exNewPred),
                                        resNewInst.TypeVector
                                        );
                    }
                                        
                    return Rebased.Passive(exCall);
                }
            }

            throw new InvalidOperationException("Unhandled method call encountered!");
        }
    }
}
