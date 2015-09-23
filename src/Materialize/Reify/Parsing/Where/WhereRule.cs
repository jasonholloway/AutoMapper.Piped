using Materialize.Info;
using Materialize.Reify.Rebasing2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace Materialize.Reify.Parsing.Where
{
    class WhereRule : QueryableMethodRule
    {
        public WhereRule(IParseStrategySource strategySource)
            : base(strategySource) { }
                

        public override IParseStrategy GetStrategy(ParseContext ctx) 
        {
            if(ctx.MethodDef == QueryableMethods.WhereDef) 
            {
                var tElem = ctx.TypeArgs.Single();
                
                var upstreamStrategy = GetUpstreamStrategy(ctx);
                
                //we have our predicate here
                var exDestPredicate = (LambdaExpression)((UnaryExpression)ctx.CallExp.Arguments[1]).Operand;

                //should split here
                //...

                //try to rebase

                //we want to rebase our where clause, which relates to a set
                //which is all well and good, but what will we rebase to?
                //we need to make a parameter specially to feed to the rebaser
                //this param will always be IQueryable<TElem>                

                //argh, why do we have to do this? seems like it would be a lot easier to package the parameter stuff into a lambda


                //the each modifier in action can 

                //var exSourceParam = Expression.Parameter(typeof(IQueryable<>)
                //                                            .MakeGenericType(ctx.MapContext.TypeVector.SourceType));


                //package below into lambda simply for rebasing pipeline: lambda form 


                var exArg0 = ctx.CallExp.Arguments.First();

                var exParam = Expression.Parameter(exArg0.Type, "en");

                var rebaseSubject = new RootedExpression(
                                                exParam,
                                                ctx.CallExp.Replace(exArg0, exParam));

                var sourceRebased = upstreamStrategy.RebaseToSource(rebaseSubject);

                if(sourceRebased != null 
                    && ctx.MapContext.QueryRegime.ServerAccepts(sourceRebased.Expression)) 
                {
                    //give to strategy to append to SourceQuery (but before other rewriting)

                    //So, we have form of rebased where predicate...
                    //But its constants will be unique each time, potentially
                    //So we can't just simply emplace it as we have it here.

                    //Options would seem to be:
                    //  > Rerun in full for each fetch
                    //  > Complicated parameterization
                    //  > Build strategies of rebasing ********
                    //
                    // STRATEGISATION!!!!!!!!!!!
                    // (doesn't have to be to same extent as parsing...)




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
