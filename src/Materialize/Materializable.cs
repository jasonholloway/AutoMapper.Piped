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
        public event EventHandler<IEnumerable> Fetched;
        public event EventHandler<IEnumerable> Transformed;

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
        Reifiable _reifiable;
        
        public Materializable(Reifiable reifiable) {
            _reifiable = reifiable;

            _reifiable.Fetched += new EventHandler<IEnumerable>((o, en) => OnFetched(en));
            _reifiable.Transformed += new EventHandler<IEnumerable>((o, en) => OnTransformed(en));
        }


        public IQueryable<TDest> Queryable {
            get { return (IQueryable<TDest>)_reifiable; }
        }

        public IEnumerator<TDest> GetEnumerator() {
            return Queryable.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return GetEnumerator();
        }
    }
}
