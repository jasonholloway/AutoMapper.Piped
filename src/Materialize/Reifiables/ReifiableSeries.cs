using Materialize.Strategies;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Materialize.Reifiables
{
    internal class ReifiableSeries<TOrig, TProj, TDest>
        : Reifiable, IMaterializable<TDest>
    {
        readonly IQueryable<TOrig> _qyOrig;
        readonly IStrategy<TOrig, TDest> _rootStrategy;
        readonly Lazy<IEnumerable<TDest>> _lzMaterialized;


        public ReifiableSeries(
                IQueryable<TOrig> qyOrig,
                IStrategy<TOrig, TDest> rootStrategy) {
            _qyOrig = qyOrig;
            _rootStrategy = rootStrategy;
            _lzMaterialized = new Lazy<IEnumerable<TDest>>(Materialize);
        }


        public override bool IsMaterialized {
            get { return _lzMaterialized.IsValueCreated; }
        }


        public override Type OrigType {
            get { return typeof(TOrig); }
        }

        public override Type ProjType {
            get { return typeof(TProj); }
        }

        public override Type DestType {
            get { return typeof(TDest); }
        }



        public override Reifiable SpawnWithModifiedQuery(
            Func<Expression, Expression> fnModifyExpression) 
        {
            var exNew = fnModifyExpression(_qyOrig.Expression);
            var qyNew = _qyOrig.Provider.CreateQuery(exNew);

            if(qyNew.ElementType != typeof(TOrig)) {
                throw new InvalidOperationException("Modified query expression must be of same type as original!");
            }

            return new ReifiableSeries<TOrig, TProj, TDest>((IQueryable<TOrig>)qyNew, _rootStrategy);
        }



        IEnumerable<TDest> Materialize() {
            var reifier = _rootStrategy.CreateReifier();

            var projectedExpression = reifier.Project(_qyOrig.Expression);

            var enProjected = (IEnumerable<TProj>)_qyOrig.Provider.CreateQuery(projectedExpression);
            OnFetched(enProjected);

            var enTransformed = (IEnumerable<TDest>)reifier.Transform(enProjected);
            OnTransformed(enTransformed);

            return enTransformed;
        }




        public IEnumerator<TDest> GetEnumerator() {
            return _lzMaterialized.Value.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return GetEnumerator();
        }

    }
}
