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
    class WhereRule : QueryableMethodRule
    {
        Config _config;


        public WhereRule(IParseStrategySource strategySource, Config config)
            : base(strategySource) 
        {
            _config = config;
        }
                

        public override IParseStrategy GetStrategy(ParseContext ctx) 
        {
            if(ctx.MethodDef == QueryableMethods.WhereDef) 
            {
                var tElem = ctx.TypeArgs.Single();
                
                var upstreamStrategy = GetUpstreamStrategy(ctx);
                
                //should split here as much as possible (ANDs can be applied in series)
                //...

                var predRebaseStrategy = GetPredicateRebaseStrategy(
                                                (LambdaExpression)((UnaryExpression)ctx.CallExp.Arguments[1]).Operand, 
                                                tElem, 
                                                upstreamStrategy,
                                                ctx.ReifyContext.SourceRegime);
                                
                if(predRebaseStrategy != null) {                                        
                    return CreateStrategy(  //we can prepend to source query!                        
                                    typeof(WhereOnServerStrategy<>)
                                                .MakeGenericType(tElem),
                                    upstreamStrategy,
                                    predRebaseStrategy);                        
                }

                if(_config.AllowClientSideFiltering) {
                    return CreateStrategy(
                                    typeof(ClientOnlyWhereStrategy<>)
                                                        .MakeGenericType(tElem),
                                    upstreamStrategy);
                }
                
                throw new MaterializationException(
                            "Can't rebase predicate to push to server, and client-side filtering forbidden!");      
            }

            return null;
        }



        IRebaseStrategy GetPredicateRebaseStrategy(
            LambdaExpression exPredLambda,
            Type tElem, 
            IParseStrategy upstreamStrategy,
            ISourceRegime sourceRegime) 
        {
            var roots = new RootVector(
                                Expression.Parameter(upstreamStrategy.DestType, "enDest"),
                                Expression.Parameter(upstreamStrategy.SourceType, "enSource"));
            
            //to rebase, each predicate has to be packed within its own where clause,
            //operating on IQueryable<TElem>. Only in this form can it be sent upstream to be rebased.                               
            
            var exSubject = Expression.Call(
                                        QueryableMethods.WhereDef.MakeGenericMethod(tElem),
                                        roots.OrigRoot,
                                        exPredLambda);

            var rebaseStrategy = upstreamStrategy.GetRebaseStrategy(
                                                        new RebaseSubject(exSubject, roots));

            //to test, need to get example result, and package in lambda (can't pass unbound param)         
            var exTest = Expression.Lambda(
                                    rebaseStrategy.Rebase(exSubject),
                                    (ParameterExpression)roots.RebasedRoot);
            
            return sourceRegime.ServerAccepts(exTest)
                                        ? rebaseStrategy
                                        : null;
        }

    }
}
