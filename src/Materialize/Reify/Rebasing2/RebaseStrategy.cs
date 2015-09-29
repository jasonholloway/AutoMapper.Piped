using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Materialize.Reify.Rebasing2
{
    class RebaseStrategy<TExp> : IRebaseStrategy<TExp>
        where TExp : Expression
    {
        Func<TExp, TExp> _fnRebase;
        
        public bool IsActive { get; private set; }
        public TypeVector TypeVector { get; private set; }
                
        public RebaseStrategy(
            TypeVector typeVector,
            Func<TExp, TExp> fnRebase = null) 
        {
            TypeVector = typeVector;            
            IsActive = fnRebase != null;
            _fnRebase = fnRebase ?? (x => x);
        }


        Expression IRebaseStrategy.Rebase(Expression exSubject) {
            return Rebase((TExp)exSubject);
        }

        public TExp Rebase(TExp exSubject) {
            return _fnRebase(exSubject);
        }

    }

}
