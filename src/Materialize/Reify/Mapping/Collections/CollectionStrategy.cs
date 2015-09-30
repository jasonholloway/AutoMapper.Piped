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


        public override IRebaseStrategy GetRebaseStrategy(RebaseSubject subject) 
        {
            var roots = subject.RootVectors.Single();

            if(roots.OrigRoot.Type != typeof(TDest) || roots.RebasedRoot.Type != typeof(TOrig)) {
                throw new InvalidOperationException();
            }
            
            var strategizer = new RebaseStrategizer(x => {
                x.AddRootStrategy(roots.OrigRoot, new RootRebaseStrategy(roots.RebasedRoot));
            });

            return strategizer.Strategize(subject.Expression);
        }


        class RootRebaseStrategy : IRootedRebaseStrategy
        {
            Expression _exRebasedRoot;

            public RootRebaseStrategy(Expression exRebasedRoot) {
                _exRebasedRoot = exRebasedRoot;
            }

            public TypeVector TypeVector {
                get { return new TypeVector(typeof(TDest), typeof(TOrig)); }
            }

            public IRebaseStrategy Expand(Expression exSubject) {
                return null; //no simple expansion here - though what about queryable methods with predicates?
            }

            //also publish elemental handler
            //elemental handler in this case would defer to elemental map strategy
            //...

            //after conversion of root, should re-root and delegate to property

            //the more I think about it, the more I'm sure that this strategy should somehow handle where clauses etc,
            //possibly through a base class. But the mechanism becomes an issue here.

            //The strategizer is absolutely needed to find the roots through establishing the structure of the tree.
            //But then behaviour across this structure belongs here. Rebasing works as a mould spreading through a
            //pre-existing structure. Something of a rebasing epiphany. Duplicative though. Each node to be strategized,
            //then the next, in an expansive movement downstream.

            //Which is all well. But what of points of confluence? Then the orchestrating strategizer must act as mediator.
            //This would happen in conditional clauses with two expression inputs (for instance). Would also occur with zips.

            //The orchestrator is primary. Fitting storehouse for common queryable handlers. And so we must instead publish
            //handlers to the orchestrating RebaseStrategizer.

            //******************************************************************


            public Expression Rebase(Expression exSubject) {
                return _exRebasedRoot;
            }
        }

    }


}
