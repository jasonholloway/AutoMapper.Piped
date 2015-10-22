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
        public Expression<Predicate<TElem>> Predicate { get; private set; }
        

        public FilterElement(Expression<Predicate<TElem>> predicate) 
            : base(ElementType.Filter) {
            Predicate = predicate;
        }









    }
}
