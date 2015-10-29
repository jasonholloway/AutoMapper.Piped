using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Materialize.Reify2.Operations
{

    abstract class FilterOp : OpBase {
        public FilterOp()
            : base(OpType.Filter) { }

        public LambdaExpression Predicate { get; protected set; } 
        public Type ElemType { get; protected set; }
    }


    class FilterOp<TElem> : FilterOp
    {

        public FilterOp(Expression<Func<TElem, bool>> predicate) 
        {
            OutType = typeof(IQueryable<TElem>);
            ElemType = typeof(TElem);
            Predicate = predicate;
        }

    }
}
