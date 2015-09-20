using Materialize.Reify.Mapping;
using Materialize.Reify.Rebasing;
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
        RebaserFactory _rebaserFac;

        public MappedBaseStrategy(IMapStrategy mapStrategy, RebaserFactory rebaserFac) {
            _mapStrategy = mapStrategy;
            _rebaserFac = rebaserFac;
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


        public RootedExpression RebaseToSource(RootedExpression subject) 
        {
            var rebaseMap = new RebaseMap();

            var rebaser = _rebaserFac.Create(rebaseMap);
            
            return rebaser.Rebase(subject);
        }
    }
}
