using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Materialize.Reify2.Transitions
{
    internal enum ElementTransitionType { First, Last, Single, ElementAt }


    internal class ElementTransition : TransitionBase
    {
        public ElementTransitionType ElementTransitionType { get; private set; }
        public bool ReturnsDefault { get; private set; }
        public Expression IndexExpression { get; private set; } //only used for ElementAt

        public ElementTransition(ElementTransitionType elemTransType, bool returnsDefault, Expression indexExp = null)
            : base(TransitionType.Partition) 
        {
            ElementTransitionType = elemTransType;
            ReturnsDefault = returnsDefault;
            IndexExpression = indexExp;
        }

        public override string ToString() {
            return $"{ElementTransitionType.ToString()}";
        }
    }
        
}
