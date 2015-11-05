using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Materialize.Reify2
{
    class ReifyQuery<TElem> : IQueryable<TElem>
    {
        public IQueryProvider Provider { get; private set; }
        public Expression Expression { get; private set; }

        Lazy<IEnumerable<TElem>> _lzResults;

        public ReifyQuery(IQueryProvider prov, Expression exp) {
            Provider = prov;
            Expression = exp;

            _lzResults = new Lazy<IEnumerable<TElem>>(
                                    () => Provider.Execute<IEnumerable<TElem>>(Expression));
        }

        public Type ElementType {
            get { return typeof(TElem); }
        }

        public IEnumerator<TElem> GetEnumerator() {
            return _lzResults.Value.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return GetEnumerator();
        }
    }



    class OrderedReifyQuery<TElem> : ReifyQuery<TElem>, IOrderedQueryable<TElem>
    {
        public OrderedReifyQuery(IQueryProvider prov, Expression exp)
            : base(prov, exp) { }
    }



}
