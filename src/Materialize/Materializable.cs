using Materialize.Reify;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Materialize
{
    class Materializable<TDest>
        : IMaterializable<TDest>
    {
        public IQueryable<TDest> Queryable { get; private set; }

        public Materializable(IQueryable<TDest> queryable) {
            Queryable = queryable;
        }

        public IEnumerator<TDest> GetEnumerator() {
            return Queryable.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return GetEnumerator();
        }
    }
}
