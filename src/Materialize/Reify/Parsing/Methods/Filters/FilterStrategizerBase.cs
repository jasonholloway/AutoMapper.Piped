using Materialize.Reify.Rebasing;
using Materialize.SourceRegimes;
using Materialize.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Materialize.Reify.Parsing.Methods.Filters
{
    abstract class FilterStrategizerBase : MethodStrategizer
    {   

        protected struct RebasePredicateResult
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
            


        protected RebasePredicateResult RebaseQuotedPredicate(UnaryExpression exPredQuotedLambda) 
        {
            if(exPredQuotedLambda.NodeType == ExpressionType.Quote) {
                return RebasePredicate((LambdaExpression)exPredQuotedLambda.Operand);
            }

            throw new InvalidOperationException();
        }

            
        protected RebasePredicateResult RebasePredicate(LambdaExpression exPredLambda) 
        {
            var rebaseSubject = GetRebaseSubject(exPredLambda);

            IRebaseStrategy rebaseStrategy = null;

            try {
                rebaseStrategy = UpstreamStrategy.GetRebaseStrategy(rebaseSubject);
            }
            catch(RebaseException ex) {
                return new RebasePredicateResult() {
                    Exception = ex
                };
            }

            bool serverAcceptible = TestAgainstServer(rebaseStrategy, rebaseSubject);

            return new RebasePredicateResult() {
                        RebaseStrategy = serverAcceptible ? rebaseStrategy : null,
                        RejectedByServer = !serverAcceptible
                        };                
        }



        //to rebase, each predicate has to be packed within its own where clause,
        //operating on IQueryable<TElem>. Only in this form can it be sent upstream to be rebased.  
        RebaseSubject GetRebaseSubject(LambdaExpression exPredLambda) 
        {   
            var roots = new RootVector(
                                Expression.Parameter(UpstreamStrategy.DestType, "enDest"),
                                Expression.Parameter(UpstreamStrategy.SourceType, "enSource"));

            var exSubject = Expression.Call(
                                        QueryableMethods.Where.MakeGenericMethod(exPredLambda.Parameters.First().Type),
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

            return Context.ReifyContext.SourceRegime.ServerAccepts(exTest);
        }
        



    }
}
