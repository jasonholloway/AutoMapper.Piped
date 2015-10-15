using Materialize.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Materialize.Reify.Parsing.Methods.Filters
{
    class WhereRule : FilterRuleBase
    {
        
        public WhereRule(IParseStrategySource strategySource)
            : base(strategySource) { }
                

        public override IParseStrategy GetStrategy(ParseContext ctx) 
        {
            if(ctx.MethodDef == QueryableMethods.WhereDef) 
            {
                var tElem = ctx.TypeArgs.Single();
                
                var upstreamStrategy = GetUpstreamStrategy(ctx);

                //should split here as much as possible (ANDs can be applied in series)
                //...
                
                var predRebaser = new PredicateRebaser(ctx, upstreamStrategy);

                var predRebaseResult = predRebaser.Rebase((LambdaExpression)((UnaryExpression)ctx.CallExp.Arguments[1]).Operand);
                

                if(predRebaseResult.Successful) {
                    return CreateStrategy(  //we can prepend to source query!                        
                                typeof(WhereOnServerStrategy<>)
                                            .MakeGenericType(tElem),
                                upstreamStrategy,
                                predRebaseResult.RebaseStrategy);
                }

                if(ctx.ReifyContext.AllowClientSideFiltering) {
                    return CreateStrategy(
                                typeof(WhereOnClientStrategy<>)
                                                    .MakeGenericType(tElem),
                                upstreamStrategy);
                }
                                
                if(predRebaseResult.Errored) {
                    throw new RebaseException(
                                "Can't rebase predicate to push to server, and client-side filtering forbidden!",
                                predRebaseResult.Exception);
                }

                if(predRebaseResult.RejectedByServer) {
                    throw new RebaseException(
                                "Server won't accept predicate, and client-side filtering forbidden!");
                }

                throw new InvalidOperationException();                                
            }

            return null;
        }
        
    }
}
