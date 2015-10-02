using Materialize.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Materialize.Reify.Rebasing.Methods.Rules
{
    class QueryableWhereRule : LinqMethodRule
    {        
        public QueryableWhereRule() 
            : base(new[] { QueryableMethods.WhereDef }) 
            { }
        

        protected override IRebaseStrategy CreateStrategy(LinqMethodContext ctx) 
        {
            var upstreamStrategy = ctx.UpstreamStrategy;

            var exPred = GetPredicate(ctx.CallExp); 
            var predStrategy = ctx.StrategizePredicate(exPred);

            var mRebasedWhere = QueryableMethods.WhereDef
                                                    .MakeGenericMethod(ctx.RebasedElemType);

            return RootedStrategy(
                            upstreamStrategy,
                            (MethodCallExpression exCall) => {                                
                                return Expression.Call(
                                                    mRebasedWhere,
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
