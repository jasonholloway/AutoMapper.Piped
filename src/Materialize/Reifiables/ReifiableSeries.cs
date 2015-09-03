using Materialize.Strategies;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Materialize.Reifiables
{
    abstract class ReifiableSeries : Reifiable
    {
        public static ReifiableSeries Create(IQueryable qyOrig, Type tDest) 
        {            
            var tOrig = qyOrig.ElementType;

            var rootStrategy = StrategySource.Default.GetStrategy(tOrig, tDest);

            var tProj = rootStrategy.ProjectedType;

            return (ReifiableSeries)Activator.CreateInstance(
                                                typeof(ReifiableSeries<,,>)
                                                            .MakeGenericType(tOrig, tProj, tDest),
                                                qyOrig,
                                                rootStrategy);
        }
    }


    class ReifiableSeries<TOrig, TProj, TDest>
        : ReifiableSeries, IMaterializable<TDest>
    {
        readonly IQueryable<TOrig> _qyOrig;
        readonly IStrategy<TOrig, TDest> _rootStrategy;
        readonly Lazy<IEnumerable<TDest>> _lzReified;

        public ReifiableSeries(
                IQueryable<TOrig> qyOrig,
                IStrategy<TOrig, TDest> rootStrategy) 
        {
            _qyOrig = qyOrig;
            _rootStrategy = rootStrategy;
            _lzReified = new Lazy<IEnumerable<TDest>>(Reify);
        }


        public override bool IsCompleted {
            get { return _lzReified.IsValueCreated; }
        }

        public override object Result {
            get { return _lzReified.Value; }
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

        public override IQueryProvider QueryProvider {
            get { return _qyOrig.Provider; }
        }

        public override Expression QueryExpression {
            get { return _qyOrig.Expression; }
        }
                

        IEnumerable<TDest> Reify() {
            var reifier = _rootStrategy.CreateReifier();

            var projectedExpression = reifier.Project(_qyOrig.Expression);

            var enProjected = (IEnumerable<TProj>)_qyOrig.Provider.CreateQuery(projectedExpression);
            OnFetched(enProjected);

            var enTransformed = (IEnumerable<TDest>)reifier.Transform(enProjected);
            OnTransformed(enTransformed);

            return enTransformed;
        }
        

        public IEnumerator<TDest> GetEnumerator() {
            return _lzReified.Value.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return GetEnumerator();
        }

    }
}
