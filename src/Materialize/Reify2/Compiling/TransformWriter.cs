using Materialize.Reify2.Transitions;
using Materialize.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Materialize.Reify2.Compiling
{
    internal static class TransformWriter
    {

        public static Expression Write(Expression exInput, IEnumerable<ITransition> steps) {
            return steps.Aggregate(exInput, (acc, step) => WriteStep(acc, (dynamic)step));
        }
        
        
        static Expression WriteStep(Expression exPrev, ProjectionTransition s) {
            return Expression.Call(
                            EnMethods.Select.MakeGenericMethod(s.InElemType, s.OutElemType),
                            exPrev,
                            s.Projection);
        }


        static Expression WriteStep(Expression exPrev, FilterTransition s) {
            return Expression.Call(
                            EnMethods.Where.MakeGenericMethod(s.ElemType),
                            exPrev,
                            s.Predicate);
        }





    }
}
