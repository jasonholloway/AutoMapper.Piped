using Materialize.Reify.Mapping;
using Materialize.Reify.Rebasing2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;


namespace Materialize.Reify.Parsing.Mapper
{
    class MapperStrategy
        : IParseStrategy
    {
        IMapStrategy _mapStrategy;
        //RebaserFactory _rebaserFac;

        public MapperStrategy(IMapStrategy mapStrategy/*, RebaserFactory rebaserFac*/) {
            _mapStrategy = mapStrategy;
            //_rebaserFac = rebaserFac;
        }


        public Type SourceType {
            get { return _mapStrategy.SourceType; }
        }

        public Type FetchType {
            get { return _mapStrategy.FetchType; }
        }
        
        public Type DestType {
            get { return _mapStrategy.TransformedType; }
        }

        public bool FiltersFetchedSet {
            get { return false; }
        }
        

        public IModifier Parse(Expression exSubject) {
            return _mapStrategy.CreateModifier();
        }

        

        //*********************************************************************************************************
        //TO DO: Have to make root strategies available corresponding to mapping hierarchy.
        //Each such strategy makes further rebase strategies available, relating to mapping layers consecutively,
        //like onion peeling.

        //MapStrategy rebasing behaviour is exposed from the root
        //ParseStrategies meddle in different regime: that of rebasing a full subject tree and passing on


        public IRebaseStrategy GetRebaseStrategy(RootedExpression subject) {
            //Below not necessarily correct now: just copied in from collection mapper

            var rootVectors = subject.Roots
                                        .Where(r => r.Type == DestType)
                                        .Select(r => new RootVector(r, Expression.Parameter(SourceType)))
                                        .ToArray();

            var strategizer = new RebaseStrategizer(
                                        GetRootRebaseStrategy,
                                        rootVectors);

            return strategizer.Strategize(subject.Expression);
        }


        IRebaseStrategy GetRootRebaseStrategy(TypeVector typeVector, ParameterExpression exRebasedRoot) 
        {
            throw new NotImplementedException();

            //if(typeVector.Equals(new TypeVector(typeof(TDest), typeof(TOrig)))) {
            //    return new RebaseStrategy<ParameterExpression>(
            //                                            typeVector,
            //                                            ex => exRebasedRoot);
            //}

            //if(typeVector.Equals(new TypeVector(typeof(TDestElem), typeof(TOrigElem)))) {
            //    //should return rebase strategy from element map strategy
            //    //should delegate here however... as exact behaviour of element mapper is its own concern

            //    //but how to pass rebased root to inferior strategy? It would seem that inferior strategy should fend for itself,
            //    //somehow. That is, once the collection root has been gathered, it should expose the element root strategy.

            //    throw new NotImplementedException();
            //}

            //return null; ;
        }




    }
}
