using Materialize.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Materialize.Reify2.Rebasing.Methods.Rules
{
    class QueryablePredicatorRule : LinqMethodRule
    {        
        public QueryablePredicatorRule() 
            : base(new[] {
                QyMethods.Where,
                QyMethods.All,
                QyMethods.Any2,
                QyMethods.Count2
            }) { }
        

        protected override IRebaseStrategy CreateStrategy(LinqMethodContext ctx) 
        {
            var upstreamStrategy = ctx.UpstreamStrategy;
            
            var exPred = GetPredicate(ctx.CallExp); 
            var predStrategy = ctx.StrategizePredicate(exPred);

            var mRebased = ctx.MethodDef.MakeGenericMethod(ctx.RebasedElemType);

            return RootedStrategy(
                            upstreamStrategy,
                            (MethodCallExpression exCall) => {                                
                                return Expression.Call(
                                                    mRebased,
                                                    upstreamStrategy.Rebase(exCall.Arguments[0]),
                                                    Expression.Quote(
                                                            predStrategy.Rebase(GetPredicate(exCall)))
                                                    );
                            });          
        }


        LambdaExpression GetPredicate(MethodCallExpression exCall) {
            return (LambdaExpression)((UnaryExpression)exCall.Arguments[1]).Operand;            
        }

    }
}
