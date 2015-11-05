using Materialize.SequenceMethods;
using System.Linq.Expressions;
using System.Collections.Generic;

namespace Materialize.Reify2.Transitions
{
    abstract class QyTransitionBase : TransitionBase
    {
        public abstract SeqMethod SeqMethod { get; }        
        public abstract IEnumerable<Expression> Args { get; }
    }
}
