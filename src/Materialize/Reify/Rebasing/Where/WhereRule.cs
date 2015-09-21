using Materialize.Reify.Rebasing.Misc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Materialize.Reify.Rebasing.Where
{
    class WhereRule : IRebaseRule
    {
        static MethodInfo _mWhereDef = Refl.GetGenMethod(() => Queryable.Where<int>(null, x =>  true)); 
        

        IRebaseStrategySource _rebaseStrategies;

        public WhereRule(IRebaseStrategySource rebaseStrategies) {
            _rebaseStrategies = rebaseStrategies;
        }
        
        public IRebaseStrategy GetStrategy(RebaseContext ctx) 
        {
            var exCall = ctx.Subject.Expression as MethodCallExpression;

            if(exCall != null 
                && exCall.Method.IsGenericMethod 
                && exCall.Method.GetGenericMethodDefinition() == _mWhereDef) 
            {
                var upstreamContext = new RebaseContext(
                                                new RootedExpression(ctx.Subject.Root, exCall.Arguments.First()),
                                                ctx.NewRoot,
                                                ctx.Map);

                var upstreamStrategy = _rebaseStrategies.GetStrategy(upstreamContext);
                
                if(!upstreamStrategy.IsPassive) 
                {                    
                    var exPredicate = (LambdaExpression)((UnaryExpression)exCall.Arguments[1]).Operand;

                    var predicateSubject = RootedExpression.FromLambda(exPredicate);

                    var predicateContext = new RebaseContext(
                                                        predicateSubject,
                                                        Expression.Parameter(
                                                                    upstreamStrategy.ActiveMap.RebasedType.GetEnumerableElementType()),
                                                        ctx.Map);
                    
                    var predicateStrategy = _rebaseStrategies.GetStrategy(predicateContext);


                    return new WhereStrategy(
                                        upstreamStrategy,
                                        predicateSubject,
                                        predicateStrategy
                                        );
                }
                else {
                    return new PassiveStrategy();
                }
            }

            return null;
        }
    }
}
