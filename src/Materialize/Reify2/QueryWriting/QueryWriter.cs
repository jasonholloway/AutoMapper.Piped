using Materialize.Reify2.Elements;
using Materialize.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Materialize.Reify2.QueryWriting
{
    internal static class QueryWriter
    {        
        public static Expression Write(Expression exBase, IEnumerable<IElement> elements) {
            return elements.Aggregate(exBase, (ac, el) => WriteEl(ac, (dynamic)el));
        }
        
                

        static Expression WriteEl<TElem>(Expression exPrev, SourceElement<TElem> el) {
            return exPrev;
        }


        static Expression WriteEl<TElem>(Expression exPrev, FilterElement<TElem> el) {
            return Expression.Call(
                            QueryableMethods.Where.MakeGenericMethod(typeof(TElem)),
                            exPrev,
                            el.Predicate);
        }



        static Expression WriteEl<TInElem, TOutElem>(Expression exPrev, ProjectorElement<TInElem, TOutElem> el) {
            return Expression.Call(
                            QueryableMethods.Select.MakeGenericMethod(typeof(TInElem), typeof(TOutElem)),
                            exPrev,
                            el.Projection);
        }
                

    }
}
