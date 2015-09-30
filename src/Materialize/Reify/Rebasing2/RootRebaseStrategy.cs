using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Materialize.Reify.Rebasing2
{
    class RootRebaseStrategy<TFinal, TRebased> : IRebaseStrategy
    {
        Func<Expression, Expression> _fnRebase;
        Func<RootVector, IRebaseStrategy> _fnRootStrategy;

        public RootRebaseStrategy(
            Func<Expression, Expression> fnRebase, 
            Func<RootVector, IRebaseStrategy> fnRootStrategy) 
        {
            _fnRebase = fnRebase;
            _fnRootStrategy = fnRootStrategy;
        }

        public TypeVector TypeVector {
            get { return new TypeVector(typeof(TFinal), typeof(TRebased)); }
        }

        public virtual IRebaseStrategy Expand(Expression exSubject) {
            return null;
        }

        public virtual IRebaseStrategy GetRootStrategy(RootVector roots) {
            return _fnRootStrategy(roots);
        }

        public virtual Expression Rebase(Expression exSubject) {
            return _fnRebase(exSubject);
        }
    }
    
}
