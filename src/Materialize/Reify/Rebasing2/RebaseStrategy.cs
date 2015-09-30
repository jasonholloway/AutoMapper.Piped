using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Materialize.Reify.Rebasing2
{
    class RebaseStrategy<TExp> : IRebaseStrategy<TExp>
        where TExp : Expression
    {
        TypeVector _typeVector;
        IRebaseStrategy _upstreamStrategy;
        Func<TExp, TExp> _fnRebase;


        public RebaseStrategy(
            IRebaseStrategy upstreamStrat,
            Func<TExp, TExp> fnRebase
            ) : this(upstreamStrat.TypeVector, upstreamStrat, fnRebase) { }


        public RebaseStrategy(
            TypeVector typeVector,
            IRebaseStrategy upstreamStrat,
            Func<TExp, TExp> fnRebase) 
        {
            _typeVector = typeVector;
            _upstreamStrategy = upstreamStrat;
            _fnRebase = fnRebase;
        }




        public TypeVector TypeVector {
            get { return _typeVector; }
        }


        public virtual IRebaseStrategy Expand(Expression exSubject) {
            return null;
        }
        

        public IRebaseStrategy GetRootStrategy(RootVector roots) {
            return _upstreamStrategy?.GetRootStrategy(roots);
        }


        public Expression Rebase(Expression exSubject) {
            return _fnRebase((TExp)exSubject);
        }

        public TExp Rebase(TExp exSubject) {
            return _fnRebase(exSubject);
        }

    }



}
