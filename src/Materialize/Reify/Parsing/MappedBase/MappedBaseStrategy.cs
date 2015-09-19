using Materialize.Reify.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;


namespace Materialize.Reify.Parsing.MappedBase
{
    class MappedBaseStrategy
        : IParseStrategy
    {
        IMapStrategy _mapStrategy;

        public MappedBaseStrategy(IMapStrategy mapStrategy) {
            _mapStrategy = mapStrategy;
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


        public Expression RebaseToSource(
            Expression exOld, 
            Expression exNew, 
            Expression exSubject) 
        {
            //This is the problematic site!!!
            //mapping strategies also need to rebase, in order to serve this.

            //mapping rebaser wouldn't deal in entire lambdaexpression, however.
            //the different layers of mapping are intra-layer, intra-lambda.

            //simple idea would be to rebase each parameter instance (as before) and then each member access of that
            //parameter. Instead of rebasing by parameter, should primarily work from accessor.

            //will often be rebased to an intermediary tuple.

            //*******************************************************************************************************
            //THOUGH THIS IS IMPOSSIBLE, AS TUPLE MEMBERS CAN'T BE REFERENCED!!! Can't, therefore, rebase to TFetch.
            //*******************************************************************************************************

            //TFetch predicates are not palatable to the server. Only TSource predicates are possible.
            

            throw new NotImplementedException();
        }
    }
}
