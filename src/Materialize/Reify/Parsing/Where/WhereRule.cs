using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace Materialize.Reify.Parsing.Where
{
    class WhereRule : QueryableMethodRule
    {
        static MethodInfo _mWhereGen = Refl.GetGenMethod(() => Queryable.Where<int>(null, i => true));

        
        public WhereRule(IParseStrategySource strategySource)
            : base(strategySource) { }

        

        public override IParseStrategy GetStrategy(ParseContext ctx) 
        {
            if(ctx.MethodDef == _mWhereGen) 
            {
                var tElem = ctx.TypeArgs.Single();
                
                var upstreamStrategy = GetUpstreamStrategy(ctx);
                
                //we have our predicate here
                var exDestPredicate = (LambdaExpression)((UnaryExpression)ctx.CallExp.Arguments[2]).Operand;

                //should split here
                //...

                //try to rebase
                var exSourceParam = Expression.Parameter(ctx.MapContext.TypeVector.SourceType);

                var exSourceRebased = upstreamStrategy.RebaseToSource(
                                                            exDestPredicate.Parameters.Single(),
                                                            exSourceParam,
                                                            exDestPredicate.Body);

                if(exSourceRebased != null 
                    && ctx.MapContext.QueryRegime.ServerAccepts(exSourceRebased)) 
                {
                    //give to strategy to append to SourceQuery (but before other rewriting)
                    throw new NotImplementedException();
                }
                else {
                    return CreateStrategy(
                                    typeof(ClientOnlyWhereStrategy<>)
                                                        .MakeGenericType(tElem),
                                    upstreamStrategy);
                }                
            }

            return null;
        }
    }
}
