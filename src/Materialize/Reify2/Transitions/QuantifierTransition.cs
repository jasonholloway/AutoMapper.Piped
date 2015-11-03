using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Materialize.Reify2.Transitions
{
    internal enum QuantifierTransitionType { Any, All, Contains }


    internal class QuantifierTransition : TransitionBase
    {
        public QuantifierTransitionType QuantifierTransitionType { get; private set; }
        public LambdaExpression Predicate { get; private set; }

        public QuantifierTransition(QuantifierTransitionType quantTransType, LambdaExpression pred = null)
            : base(TransitionType.Quantifier) 
        {
            QuantifierTransitionType = quantTransType;
            Predicate = pred;
        }

        public override string ToString() {
            return $"{QuantifierTransitionType.ToString()}";
        }
    }
        
}
