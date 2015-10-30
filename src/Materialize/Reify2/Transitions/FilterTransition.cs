using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Materialize.Reify2.Transitions
{

    internal class FilterTransition : TransitionBase
    {

        public LambdaExpression Predicate { get; protected set; }
        public Type ElemType { get; protected set; }


        public FilterTransition(LambdaExpression exPred)
            : base(TransitionType.Filter) 
        {
            Debug.Assert(exPred.Parameters.Count == 1);
            Debug.Assert(exPred.ReturnType == typeof(bool));

            Predicate = exPred;
            ElemType = exPred.Parameters[0].Type;
        }

    }
        
}
