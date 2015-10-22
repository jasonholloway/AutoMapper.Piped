using Materialize.CollectionFactories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Materialize.Reify2.Rebasing;
using Materialize.Reify2.Parsing;
using Materialize.Types;

namespace Materialize.Reify2.Mapping.Collections
{
    abstract class CollectionStrategyBase<TOrig, TOrigElem, TDestElem, TDest>
        : MapStrategyBase<TOrig, TDest>
        where TOrig : IEnumerable<TOrigElem>
    {
        protected IMapStrategy _elemStrategy;

        public CollectionStrategyBase(IMapStrategy elemStrategy) {
            _elemStrategy = elemStrategy;
        }

        
        public override IRebaseStrategy GetRootRebaseStrategy(RootVector roots) 
        {            
            if(roots.TypeVector.Equals(new TypeVector(typeof(TDest), typeof(TOrig)))) {
                return new RootRebaseStrategy<TDest, TOrig>(
                                        ex => roots.RebasedRoot,
                                        rv => GetRootRebaseStrategy(rv));
            }
            
            if(roots.TypeVector.Equals(new TypeVector(typeof(TDestElem), typeof(TOrigElem)))) {
                return _elemStrategy.GetRootRebaseStrategy(roots);
            }

            return base.GetRootRebaseStrategy(roots);
        }


        public override IEnumerable<IReifyStrategy> UpstreamStrategies {
            get { return new IReifyStrategy[] { _elemStrategy }; }
        }

    }


}
