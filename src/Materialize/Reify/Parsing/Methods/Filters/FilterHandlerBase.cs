using Materialize.Reify.Rebasing;
using Materialize.SourceRegimes;
using Materialize.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Materialize.Reify.Parsing.Methods.Filters
{
    abstract class FilterParserBase : MethodParserBase
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
            

        

        protected RebasePredicateResult RebasePredicateToSource(LambdaExpression exPredLambda) 
        {
            var rebaseSubject = GetRebaseSubject(exPredLambda);

            IRebaseStrategy rebaseStrategy = null;

            try {
                rebaseStrategy = UpstreamStrategy.RebaseToSource(rebaseSubject); // UpstreamStrategy.RebaseToSourceType(rebaseSubject);
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
            
        
        protected RebasePredicateResult RebasePredicateToSource(UnaryExpression exPredQuotedLambda) {
            if(exPredQuotedLambda.NodeType == ExpressionType.Quote) {
                return RebasePredicateToSource((LambdaExpression)exPredQuotedLambda.Operand);
            }

            throw new ArgumentException("Should be quote!", nameof(exPredQuotedLambda));
        }
        



        //if we're going to be rebasing other filters, then there should be some flexibility in packaging the subject
        //of the rebase operation.


        //to rebase, each predicate has to be packed within its own where clause,
        //operating on IQueryable<TElem>. Only in this form can it be sent upstream to be rebased.  
        RebaseSubject GetRebaseSubject(LambdaExpression exPredLambda) 
        {   
            var roots = new RootVector(
                                Expression.Parameter(UpstreamStrategy.DestType, "enDest"),
                                Expression.Parameter(UpstreamStrategy.SourceType, "enSource"));

            var exSubject = Expression.Call(
                                        MethodDef.MakeGenericMethod(exPredLambda.Parameters.First().Type), //this is somewhat nasty! relies on filter method having predicate as second arg
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
