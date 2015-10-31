using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Materialize.Reify2.Transitions
{
    internal enum PartitionType { Take, Skip }


    internal class PartitionTransition : TransitionBase
    {
        public PartitionType PartitionType { get; private set; }
        public Expression CountExpression { get; private set; }

        public PartitionTransition(PartitionType partType, Expression exCount)
            : base(TransitionType.Filter) 
        {
            PartitionType = partType;
            CountExpression = exCount;
        }

    }
        
}
