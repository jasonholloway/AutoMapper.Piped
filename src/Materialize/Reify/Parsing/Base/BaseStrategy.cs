using Materialize.Reify.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;


namespace Materialize.Reify.Parsing.Unaries
{
    class BaseStrategy
        : IParseStrategy
    {
        IMapStrategy _mapStrategy;

        public BaseStrategy(IMapStrategy mapStrategy) {
            _mapStrategy = mapStrategy;
        }

        public bool FiltersFetchedSet {
            get { return false; }
        }
        
        public IModifier Parse(Expression exSubject) {
            return _mapStrategy.CreateModifier();
        }
    }
}
