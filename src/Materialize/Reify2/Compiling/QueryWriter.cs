using Materialize.Reify2.Transitions;
using Materialize.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Materialize.Reify2.Compiling
{
    internal static class QueryWriter
    {   

        public static Expression Write(Expression exBase, IEnumerable<ITransition> elements) {
            return elements.Aggregate(exBase, (ac, el) => WriteStep(ac, (dynamic)el));
        }
        
                

        static Expression WriteStep(Expression exPrev, SourceTransition s) {
            return exPrev;
        }


        static Expression WriteStep(Expression exPrev, FilterTransition s) {
            return Expression.Call(
                            QueryableMethods.Where.MakeGenericMethod(s.ElemType),
                            exPrev,
                            s.Predicate);
        }
        

        static Expression WriteStep(Expression exPrev, ProjectionTransition s) {
            return Expression.Call(
                            QueryableMethods.Select.MakeGenericMethod(s.InElemType, s.OutElemType),
                            exPrev,
                            s.Projection);
        }
                

    }
}
