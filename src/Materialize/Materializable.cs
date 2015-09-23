using Materialize.Reify;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Materialize
{
    internal abstract class Materializable
    {
        public event EventHandler<IQueryable> Queried;
        public event EventHandler<IEnumerable> Fetched;
        public event EventHandler<IEnumerable> Transformed;

        protected void OnQueried(IQueryable query) {
            if(Queried != null) {
                Queried(this, query);
            }
        }

        protected void OnFetched(IEnumerable elems) {
            if(Fetched != null) {
                Fetched(this, elems);
            }
        }

        protected void OnTransformed(IEnumerable elems) {
            if(Transformed != null) {
                Transformed(this, elems);
            }
        }
    }


    class Materializable<TDest>
        : Materializable, IMaterializable<TDest>
    {
        IQueryable<TDest> _query;
        

        public Materializable(IQueryable<TDest> query)
        {
            _query = query;

            var reifiable = (Reifiable)_query.Provider;
            reifiable.QueryToServer += new EventHandler<IQueryable>((o, q) => OnQueried(q));
            reifiable.Fetched += new EventHandler<IEnumerable>((o, en) => OnFetched(en));
            reifiable.Transformed += new EventHandler<IEnumerable>((o, en) => OnTransformed(en));
        }


        public IQueryable<TDest> AsQueryable() {
            return _query;
        }

        public IEnumerator<TDest> GetEnumerator() {
            return _query.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return GetEnumerator();
        }
    }
}
