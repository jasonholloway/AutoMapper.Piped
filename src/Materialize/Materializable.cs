using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Materialize
{
    internal interface ISnoopableMaterializable
    {
        event EventHandler<IEnumerable> Fetched;
        event EventHandler<IEnumerable> Transformed;
    }


    internal abstract class Materializable : ISnoopableMaterializable
    {
        //protected readonly object Sync;
        
        public event EventHandler<IEnumerable> Fetched;
        public event EventHandler<IEnumerable> Transformed;
        
        public abstract Type OrigType { get; }
        public abstract Type ProjType { get; }
        public abstract Type DestType { get; }


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


        public abstract Materializable CloneWithModifiedQuery(Func<Expression, Expression> fnModifyExpression);

        
        public abstract bool IsMaterialized { get; }
                
              


        

        public static IMaterializable<TDest> Create<TDest>(IQueryable qyOrig) {
            //should create singles too...
            //...

            var tOrig = qyOrig.ElementType;
            var tDest = typeof(TDest);

            var rootStrategy = ReifierSource.Default.GetStrategy(tOrig, tDest);
            var tProj = rootStrategy.ProjectedType;

            return (IMaterializable<TDest>)Activator.CreateInstance(
                                                        typeof(MaterializableSeries<,,>)
                                                                    .MakeGenericType(tOrig, tProj, tDest),
                                                        qyOrig,
                                                        rootStrategy);
        }

    }



    internal class MaterializableSingle<TOrig, TProj, TDest>
        : Materializable
    {
        readonly IQueryable<TOrig> _qyOrig;
        readonly IReifyStrategy<TOrig, TDest> _rootStrategy;

        public MaterializableSingle(
            IQueryable<TOrig> qyOrig, 
            IReifyStrategy<TOrig, TDest> rootStrategy) 
        {
            _qyOrig = qyOrig;
            _rootStrategy = rootStrategy;
        }

        public override bool IsMaterialized {
            get {
                throw new NotImplementedException();
            }
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



        TDest Materialize() {
            throw new NotImplementedException();
        }


        public override Materializable CloneWithModifiedQuery(
            Func<Expression, Expression> fnModifyExpression) 
        {
            throw new NotImplementedException(); //don't think this will ever need implementing...
        }
    }



    internal class MaterializableSeries<TOrig, TProj, TDest> 
        : Materializable, IMaterializable<TDest>
    {
        readonly IQueryable<TOrig> _qyOrig;
        readonly IReifyStrategy<TOrig, TDest> _rootStrategy;
        readonly Lazy<IEnumerable<TDest>> _lzMaterialized;


        public MaterializableSeries(
                IQueryable<TOrig> qyOrig, 
                IReifyStrategy<TOrig, TDest> rootStrategy) 
            {
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



        public override Materializable CloneWithModifiedQuery(
            Func<Expression, Expression> fnModifyExpression) 
        {
            var exNew = fnModifyExpression(_qyOrig.Expression);
            var qyNew = _qyOrig.Provider.CreateQuery(exNew);

            if(qyNew.ElementType != typeof(TOrig)) {
                throw new InvalidOperationException("Modified query expression must be of same type as original!");
            }

            return new MaterializableSeries<TOrig, TProj, TDest>((IQueryable<TOrig>)qyNew, _rootStrategy);
        }


        
        IEnumerable<TDest> Materialize() 
        {
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
