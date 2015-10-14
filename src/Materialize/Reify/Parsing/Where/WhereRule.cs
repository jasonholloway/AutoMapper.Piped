using Materialize.Types;
using Materialize.Reify.Rebasing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using Materialize.SourceRegimes;
using Materialize.Expressions;

namespace Materialize.Reify.Parsing.Where
{
    class WhereRule : QueryableMethodWithPredicateRule
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



                //below should be handled by special action class
                //...

                
                if(predRebaseResult.RejectedByServer && !ctx.ReifyContext.AllowClientSideFiltering) {
                    throw new MaterializationException(
                                "Server won't accept predicate, and client-side filtering forbidden!");
                }

                if(predRebaseResult.Exception != null && !ctx.ReifyContext.AllowClientSideFiltering) {
                    throw new RebaseException(
                                "Can't rebase predicate to push to server, and client-side filtering forbidden!",
                                predRebaseResult.Exception);
                }
                                
                if(predRebaseResult.RebaseStrategy != null) {
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
                
                throw new MaterializationException(
                            "Server won't accept predicate, and client-side filtering forbidden!");       //EURGH!
            }

            return null;
        }




        //RebaseSubject GetRebaseSubject(
        //    LambdaExpression exPredLambda,
        //    Type tSource) 
        //{
        //    var tElem = exPredLambda.Parameters.First().Type;
        //    var tDest = typeof(IQueryable<>).MakeGenericType(tElem);

        //    var roots = new RootVector(
        //                        Expression.Parameter(tDest, "enDest"),
        //                        Expression.Parameter(tSource, "enSource"));

        //    //to rebase, each predicate has to be packed within its own where clause,
        //    //operating on IQueryable<TElem>. Only in this form can it be sent upstream to be rebased.                               

        //    var exSubject = Expression.Call(
        //                                QueryableMethods.WhereDef.MakeGenericMethod(tElem),
        //                                roots.OrigRoot,
        //                                exPredLambda);

        //    return new RebaseSubject(exSubject, roots);
        //}
                

        //bool TestRebaseStrategyAgainstServer(
        //    ISourceRegime sourceRegime,
        //    RebaseSubject subject, 
        //    IRebaseStrategy rebaseStrategy) 
        //{
        //    //to test, need to get example result, and package in lambda (can't pass unbound param)         
        //    var exTest = Expression.Lambda(
        //                            rebaseStrategy.Rebase(subject.Expression),
        //                            (ParameterExpression)subject.RootVectors[0].RebasedRoot);

        //    return sourceRegime.ServerAccepts(exTest);
        //}

    }
}
