using Materialize.Info;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Materialize.Reify.Rebasing.Where
{
    class WhereStrategy : IRebaseStrategy
    {
        IRebaseStrategy _upstreamStrategy;
        RootedExpression _predicateSubject;
        IRebaseStrategy _predicateStrategy;

        public WhereStrategy(
            IRebaseStrategy upstreamStrategy, 
            RootedExpression predicateSubject,
            IRebaseStrategy predicateStrategy) 
        {
            _upstreamStrategy = upstreamStrategy;
            _predicateSubject = predicateSubject;
            _predicateStrategy = predicateStrategy;
        }

        public bool IsPassive {
            get { return _upstreamStrategy.IsPassive; }
        }

        public RebaseMap ActiveMap {
            get { return _upstreamStrategy.ActiveMap; }
        }

        public RootedExpression Rebase(RootedExpression subject) 
        {
            var upstreamRebased = _upstreamStrategy.Rebase(subject);
                        
            var exRebasedPred = _predicateStrategy.Rebase(_predicateSubject)
                                                    .ToLambda();

            var mWhere = QueryableMethods.WhereDef.MakeGenericMethod(
                                                        upstreamRebased.Expression.Type.GetEnumerableElementType());
            
            return new RootedExpression(
                                upstreamRebased.Root,
                                Expression.Call(
                                            mWhere,
                                            upstreamRebased.Expression,
                                            exRebasedPred
                                            ));            
        }



        //if no caching involved, then the role of the strategy is really to define the rebase context downstream.
        //a visitor could do the same. Go upstream, get a rebased 


    }
}
