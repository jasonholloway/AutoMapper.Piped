using Materialize.Reify.Rebasing;
using Materialize.SourceRegimes;
using Materialize.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Materialize.Reify.Parsing.Methods.Filters
{
    abstract class RebasingHandlerBase : MethodHandlerBase
    {   

        protected class RebasePredicateResult
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

            public Exception GetException() {
                if(Errored) {
                    throw new RebaseException(
                                "Can't rebase predicate to push to server, and client-side filtering forbidden!",
                                Exception);
                }

                if(RejectedByServer) {
                    throw new RebaseException(
                                "Server won't accept predicate, and client-side filtering forbidden!");
                }

                throw new InvalidOperationException("RebasePredicateResult.GetException() called inappropriately!");
            }

        }
            


        protected RebasePredicateResult RebaseToSource(RebaseSubject subject) 
        {
            IRebaseStrategy rebaseStrategy = null;

            try {
                rebaseStrategy = UpstreamStrategy.RebaseToSource(subject); // UpstreamStrategy.RebaseToSourceType(rebaseSubject);
            }
            catch(RebaseException ex) {
                return new RebasePredicateResult() {
                    Exception = ex
                };
            }

            bool serverAcceptible = TestAgainstServer(rebaseStrategy, subject);

            return new RebasePredicateResult() {
                RebaseStrategy = serverAcceptible ? rebaseStrategy : null,
                RejectedByServer = !serverAcceptible
            };
        }



        protected RebasePredicateResult RebasePredicateToSource(LambdaExpression exPredicate) 
        {
            var subject = GetPredicateRebaseSubject(exPredicate);
            return RebaseToSource(subject);
        }
            
        
        protected RebasePredicateResult RebasePredicateToSource(UnaryExpression exPredicate) {
            if(exPredicate.NodeType == ExpressionType.Quote) {
                return RebasePredicateToSource((LambdaExpression)exPredicate.Operand);
            }

            throw new ArgumentException("Should be quote!", nameof(exPredicate));
        }
        



        //if we're going to be rebasing other filters, then there should be some flexibility in packaging the subject
        //of the rebase operation.


        //to rebase, each predicate has to be packed within its own where clause,
        //operating on IQueryable<TElem>. Only in this form can it be sent upstream to be rebased.  
        RebaseSubject GetPredicateRebaseSubject(LambdaExpression exPredicate) 
        {   
            var roots = new RootVector(
                                exPredicate.Parameters.Single(),
                                Expression.Parameter(UpstreamStrategy.SourceType.GetEnumerableElementType(), "s"));
            
            return new RebaseSubject(exPredicate, roots);
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
