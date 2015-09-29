﻿using Materialize.CollectionFactories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Materialize.Reify.Parsing;
using Materialize.Reify.Rebasing2;

namespace Materialize.Reify.Mapping.Collections
{
    class DirectCollectionStrategy<TOrig, TOrigElem, TDestElem, TDest>
        : StrategyBase<TOrig, TDest>
        where TOrig : IEnumerable<TOrigElem>
    {
        MapContext _ctx;
        CollectionFactory _collFactory;
        IMapStrategy _elemStrategy;
        
        public DirectCollectionStrategy(
            MapContext ctx, 
            CollectionFactory collFactory, 
            IMapStrategy elemStrategy) 
        {
            _ctx = ctx;
            _collFactory = collFactory;
            _elemStrategy = elemStrategy;
        }
        
        public override Type FetchType {
            get { return typeof(IEnumerable<TOrigElem>); }
        }

        public override bool RewritesExpression {
            get { return false; }
        }

        public override IModifier CreateModifier() {
            return new Mapper(_ctx, _collFactory, _elemStrategy);
        }
                
        

        class Mapper : MapperModifier<IEnumerable<TOrigElem>, IEnumerable<TOrigElem>, TDest>
        {
            MapContext _ctx;
            CollectionFactory _collFactory;
            IModifier _elemModifier;

            public Mapper(MapContext ctx, CollectionFactory collFactory, IMapStrategy elemStrategy) {
                _ctx = ctx;
                _collFactory = collFactory;
                _elemModifier = elemStrategy.CreateModifier();
            }
            
            public override Expression Rewrite(Expression exSource) {
                return exSource;
            }

            protected override TDest Transform(IEnumerable<TOrigElem> fetched) {
                var transformedElems = fetched
                                        .Select(elem => _elemModifier.Transform(elem));

                return (TDest)_collFactory(transformedElems); //wrap into proper destination collection type
            }
        }




        public override IRebaseStrategy GetRebaseStrategy(RootedExpression subject) {
            throw new NotImplementedException();
        }

    }


}
