using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Materialize
{
    class Materializable
    {
        public static IMaterializable<TDest> Create<TDest>(IQueryable qyOrig) 
        {            
            var tOrig = qyOrig.ElementType;
            var tDest = typeof(TDest);

            var rootStrategy = ReifierSource.Default.GetStrategy(tOrig, tDest);
            var tProj = rootStrategy.ProjectedType;
                                    
            return (IMaterializable<TDest>)Activator.CreateInstance(
                                                        typeof(Materializable<,,>)
                                                                    .MakeGenericType(tOrig, tProj, tDest),
                                                        qyOrig,
                                                        rootStrategy);
        }
    }
 

    class Materializable<TOrig, TProj, TDest> : IMaterializable<TDest>
    {
        IQueryable<TOrig> _qyOrig;
        IReifyStrategy<TOrig, TDest> _rootStrategy;
        Lazy<IEnumerable<TDest>> _lzMaterialized;
        

        public Materializable(
                IQueryable<TOrig> qyOrig, 
                IReifyStrategy<TOrig, TDest> rootStrategy) 
            {
                _qyOrig = qyOrig;
                _rootStrategy = rootStrategy;
                _lzMaterialized = new Lazy<IEnumerable<TDest>>(Materialize);        
            }
        

        public bool IsMaterialized {
            get { return _lzMaterialized.IsValueCreated; }
        }
               

        IEnumerable<TDest> Materialize() 
        {
            //Should only materialize once! Should cache!
            //...

            //Should lock projection and transformation, so as not to re-query
            //...

            var reifier = _rootStrategy.CreateReifier();

            var projectedExpression = reifier.Project(_qyOrig.Expression);

            var enProjected = (IEnumerable<TProj>)_qyOrig.Provider.CreateQuery(projectedExpression);

            var enTransformed = (IEnumerable<TDest>)reifier.Transform(enProjected);

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
