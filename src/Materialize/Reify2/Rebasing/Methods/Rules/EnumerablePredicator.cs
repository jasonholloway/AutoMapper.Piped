using Materialize.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace Materialize.Reify2.Rebasing.Methods.Rules
{
    class EnumerablePredicatorRule : LinqMethodRule
    {                
        public EnumerablePredicatorRule() 
            : base(new[] {
                    EnumerableMethods.Where,
                    EnumerableMethods.AnyPred,
                    EnumerableMethods.CountPred
                }) 
            { }
        

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
                                                predStrategy.Rebase(GetPredicate(exCall)));
                            });          
        }


        LambdaExpression GetPredicate(MethodCallExpression exCall) {
            return (LambdaExpression)exCall.Arguments[1];            
        }

    }
}
