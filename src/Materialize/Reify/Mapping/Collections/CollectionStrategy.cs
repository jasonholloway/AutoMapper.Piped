using Materialize.CollectionFactories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Materialize.Reify.Rebasing2;
using Materialize.Reify.Parsing;

namespace Materialize.Reify.Mapping.Collections
{
    class CollectionStrategy<TOrig, TOrigElem, TMedElem, TDestElem, TDest>
        : StrategyBase<TOrig, TDest>
        where TOrig : IEnumerable<TOrigElem>
    {
        MapContext _ctx;
        CollectionFactory _collFactory;
        IMapStrategy _elemStrategy;
        
        public CollectionStrategy(
            MapContext ctx, 
            CollectionFactory collFactory, 
            IMapStrategy elemStrategy) 
        {
            _ctx = ctx;
            _collFactory = collFactory;
            _elemStrategy = elemStrategy;
        }
        
        public override Type FetchType {
            get { return typeof(IEnumerable<TMedElem>); }
        }
        
        public override IModifier CreateModifier() {
            return new Mapper(_collFactory, _elemStrategy);
        }
                
        

        class Mapper : MapperModifier<IEnumerable<TOrigElem>, IEnumerable<TMedElem>, TDest>
        {
            static MethodInfo _mQueryableSelect = Refl.GetMethod(() => Queryable.Select(null, (Expression<Func<TOrigElem, TMedElem>>)null));
            static MethodInfo _mEnumerableSelect = Refl.GetMethod(() => Enumerable.Select(null, (Func<TOrigElem, TMedElem>)null));
            

            CollectionFactory _collFactory;
            IMapStrategy _elemStrategy;
            IModifier _elemModifier;
            
            public Mapper(
                CollectionFactory collFactory, 
                IMapStrategy elemStrategy) 
            {
                _collFactory = collFactory;
                _elemStrategy = elemStrategy;
                _elemModifier = elemStrategy.CreateModifier();
            }


            public override Expression Rewrite(Expression exQuery) 
            {
                var exInParam = Expression.Parameter(typeof(TOrigElem));
                var exLambdaBody = _elemModifier.Rewrite(exInParam);
                
                return Expression.Call(
                                    exQuery.Type.IsQueryable()
                                        ? _mQueryableSelect
                                        : _mEnumerableSelect,
                                    exQuery,
                                    Expression.Lambda(
                                                typeof(Func<TOrigElem, TMedElem>),
                                                exLambdaBody,
                                                exInParam)
                                    );
            }
                        
            protected override TDest Transform(IEnumerable<TMedElem> fetched) {
                var transformedElems = fetched
                                        .Select(elem => _elemModifier.Transform(elem));

                return (TDest)_collFactory(transformedElems);
            }
        }

        

        //*********************************************************************************************


        //below rebase method should be moved to common collection base class
        //...

        public override IRebaseStrategy GetRebaseStrategy(RebaseSubject subject) 
        {
            var roots = subject.RootVectors.Single();

            if(roots.OrigRoot.Type != typeof(TDest) || roots.RebasedRoot.Type != typeof(TOrig)) {
                throw new InvalidOperationException();
            }
            
            var strategizer = new RebaseStrategizer(x => {
                x.AddRootStrategy(
                    roots.OrigRoot, 
                    new RootRebaseStrategy<TDest, TOrig>(
                                    ex => roots.RebasedRoot,
                                    rv => { throw new NotImplementedException(); } //need to delegate to element map strategy here...
                                    ));
            });

            return strategizer.Strategize(subject.Expression);
        }

        
    }


}
