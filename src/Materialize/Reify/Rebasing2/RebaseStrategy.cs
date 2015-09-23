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

        public bool IsRooted { get; private set; }
        public bool IsActive { get; private set; }
        public TypeVector TypeVector { get; private set; }
        public IReadOnlyDictionary<ParameterExpression, ParameterExpression> Roots { get; private set; }
                
        public RebaseStrategy(
            TypeVector typeVector,
            IReadOnlyDictionary<ParameterExpression, ParameterExpression> dRoots = null,
            Func<TExp, TExp> fnRebase = null) 
        {
            TypeVector = typeVector;

            Roots = dRoots ?? new Dictionary<ParameterExpression, ParameterExpression>();
            IsRooted = Roots.Any();

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
