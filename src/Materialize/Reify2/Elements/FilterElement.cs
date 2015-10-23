using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Materialize.Reify2.Elements
{
    class FilterElement<TElem> : ElementBase
    {
        public Expression<Func<TElem, bool>> Predicate { get; private set; }
        

        public FilterElement(Expression<Func<TElem, bool>> predicate) 
            : base(ElementType.Filter) 
        {
            OutType = typeof(IQueryable<TElem>);
            Predicate = predicate;
        }

    }
}
