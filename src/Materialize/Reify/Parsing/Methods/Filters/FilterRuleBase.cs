using Materialize.Reify.Rebasing;
using Materialize.SourceRegimes;
using Materialize.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Materialize.Reify.Parsing.Methods.Filters
{
    abstract class FilterRuleBase : MethodRule
    {
        public FilterRuleBase(IParseStrategySource parseStrategies)
            : base(parseStrategies) { }

        

        protected class PredicateRebaser
        {
            ParseContext _ctx;
            IParseStrategy _upstreamStrategy;
            
            public PredicateRebaser(ParseContext ctx, IParseStrategy upstreamStrategy) {
                _ctx = ctx;
                _upstreamStrategy = upstreamStrategy;
            }


            public struct Result
            {
                public IRebaseStrategy RebaseStrategy;
                public Exception Exception;
                public bool RejectedByServer;

                public bool Successful {
                    get { return RebaseStrategy != null; }
                }

                public bool Errored {
                    get { return Exception != null; }
                }
            }
            
            
            public Result Rebase(LambdaExpression exPredLambda) 
            {
                var rebaseSubject = GetRebaseSubject(exPredLambda);

                IRebaseStrategy rebaseStrategy = null;

                try {
                    rebaseStrategy = _upstreamStrategy.GetRebaseStrategy(rebaseSubject);
                }
                catch(RebaseException ex) {
                    return new Result() {
                        Exception = ex
                    };
                }

                bool serverAcceptible = TestAgainstServer(rebaseStrategy, rebaseSubject);

                return new Result() {
                            RebaseStrategy = serverAcceptible ? rebaseStrategy : null,
                            RejectedByServer = !serverAcceptible
                            };                
            }



            //to rebase, each predicate has to be packed within its own where clause,
            //operating on IQueryable<TElem>. Only in this form can it be sent upstream to be rebased.  
            RebaseSubject GetRebaseSubject(LambdaExpression exPredLambda) 
            {   
                var roots = new RootVector(
                                    Expression.Parameter(_upstreamStrategy.DestType, "enDest"),
                                    Expression.Parameter(_upstreamStrategy.SourceType, "enSource"));

                var exSubject = Expression.Call(
                                            QueryableMethods.WhereDef.MakeGenericMethod(exPredLambda.Parameters.First().Type),
                                            roots.OrigRoot,
                                            exPredLambda);

                return new RebaseSubject(exSubject, roots);
            }


            //to test, need to get example result, and package in lambda (can't pass unbound param)   
            bool TestAgainstServer(
                IRebaseStrategy rebaseStrategy,
                RebaseSubject subject) 
            {      
                var exTest = Expression.Lambda(
                                        rebaseStrategy.Rebase(subject.Expression),
                                        (ParameterExpression)subject.RootVectors[0].RebasedRoot);

                return _ctx.ReifyContext.SourceRegime.ServerAccepts(exTest);
            }



        }








    }
}
