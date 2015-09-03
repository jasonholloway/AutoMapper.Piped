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

        //public IStrategy RootStrategy {
        //    get { return _rootStrategy; }
        //}

        public override Type OrigType {
            get { return typeof(TOrig); }
        }

        public override Type ProjType {
            get { return typeof(TProj); }
        }

        public override Type DestType {
            get { return typeof(TDest); }
        }



        
        ///////////////////////////////////////////////////////////////////////////////
        //BELOW IS MESS!!!!!!!!!!!!!!!
          
        //nasty interface below: should be more elegant way of doing this
        //than arbitrarily exposing function as public.
       
        //how about if ReifiableSeries had internal-only IQueryable interface?
        //users would still get IMaterializable, but this would delegate to IQueryable in a controlled manner
        
        //...


        IEnumerable<TDest> Reify() {
            return (IEnumerable<TDest>)Reify(null);
        }


        public object Reify(Func<Expression, Expression> fnModifyExp) {
            var reifier = _rootStrategy.CreateReifier();

            var projExp = reifier.Project(_qyOrig.Expression);

            if(fnModifyExp != null) {
                projExp = fnModifyExp(projExp);
            }

            if(typeof(IQueryable<TProj>).IsAssignableFrom(projExp.Type)) {
                var enProjected = (IEnumerable<TProj>)_qyOrig.Provider.CreateQuery(projExp);
                OnFetched(enProjected);

                var enTransformed = (IEnumerable<TDest>)reifier.Transform(enProjected);
                OnTransformed(enTransformed);

                return enTransformed;
            }
            else {
                var fetched = _qyOrig.Provider.Execute<TProj>(projExp);
                OnFetched(new[] { fetched });

                var transformed = (TDest)reifier.Transform(fetched);
                OnTransformed(new[] { transformed });

                return transformed;
            }
        }


        //public TDest ReifySingle(Func<Expression, Expression> fnModifyExp) 
        //{
        //    var reifier = _rootStrategy.CreateReifier();

        //    var projExp = reifier.Project(_qyOrig.Expression);
        //    var modProjExp = fnModifyExp(projExp);

        //    var fetched = _qyOrig.Provider.Execute<TProj>(modProjExp);
        //    OnFetched(new[] { fetched });

        //    var transformed = (TDest)reifier.Transform(fetched);
        //    OnTransformed(new[] { transformed });

        //    return transformed;
        //}


        //public IEnumerable<TDest> ReifySeries(Func<Expression, Expression> fnModifyExp) 
        //{
        //    var reifier = _rootStrategy.CreateReifier();

        //    var projectedExpression = reifier.Project(_qyOrig.Expression);

        //    if(fnModifyExp != null) {
        //        projectedExpression = fnModifyExp(projectedExpression);
        //    }

        //    var enProjected = (IEnumerable<TProj>)_qyOrig.Provider.CreateQuery(projectedExpression);
        //    OnFetched(enProjected);

        //    var enTransformed = (IEnumerable<TDest>)reifier.Transform(enProjected);
        //    OnTransformed(enTransformed);

        //    return enTransformed;
        //}
        


        public IEnumerator<TDest> GetEnumerator() {
            return _lzReified.Value.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return GetEnumerator();
        }

    }
}
