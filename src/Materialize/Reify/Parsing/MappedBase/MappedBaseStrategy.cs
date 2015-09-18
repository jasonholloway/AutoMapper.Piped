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
            get { return _mapStrategy.FetchedType; }
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
    }
}
