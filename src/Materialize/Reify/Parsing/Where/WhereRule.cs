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
                var exInst = ctx.CallExp.Arguments[0];

                var exPredicate = (LambdaExpression)((UnaryExpression)ctx.CallExp.Arguments[1]).Operand;

                //should split here as much as possible (ANDs can be applied in series)
                //...
                
                //eeeeh.... to rebase, each predicate will have to be packed within its own where clause,
                //operating on IQueryable<TElem>. Only in this form can it be sent upstream to be rebased.                                
                

                var roots = new RootVector(
                                    Expression.Parameter(upstreamStrategy.DestType),
                                    Expression.Parameter(upstreamStrategy.SourceType)); //GET THE SOURCE TYPE TO REBASE TO!!!


                var exRebaseSubject = Expression.Call(
                                            QueryableMethods.WhereDef.MakeGenericMethod(tElem),
                                            roots.OrigRoot,
                                            exPredicate);
                
                var rebaseStrategy = upstreamStrategy.GetRebaseStrategy(
                                                            new RebaseSubject(exRebaseSubject, roots));

                
                if(rebaseStrategy != null) {
                    var exTest = rebaseStrategy.Rebase(exRebaseSubject);
                    
                    if(ctx.MapContext.QueryRegime.ServerAccepts(exTest)) 
                    {
                        //we can prepend to source query!                        
                        return CreateStrategy(
                                        typeof(WhereOnServerStrategy<>)
                                                    .MakeGenericType(tElem),
                                        upstreamStrategy,
                                        rebaseStrategy);                        
                    }
                }


                return CreateStrategy(
                                typeof(ClientOnlyWhereStrategy<>)
                                                    .MakeGenericType(tElem),
                                upstreamStrategy);                
            }

            return null;
        }
    }
}
