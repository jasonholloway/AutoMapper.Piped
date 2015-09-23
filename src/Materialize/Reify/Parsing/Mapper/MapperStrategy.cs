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


        public RootedExpression RebaseToSource(RootedExpression subject) 
        {
            var memberRebaser = new MappedMemberRebaser(); //should pack with all applied projections

            var rebaser = new Rebaser(memberRebaser);
            
            var exNewRoot = Expression.Parameter(SourceType, "r");
            rebaser.Roots[subject.Root] = exNewRoot;

            return new RootedExpression(
                                exNewRoot, 
                                rebaser.Rebase(subject.Expression));
        }
    }
}
