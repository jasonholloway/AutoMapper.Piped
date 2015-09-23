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


        public IRebaseStrategy GetRebaseStrategy(RootedExpression subject) 
        {
            var memberStrategizer = new MappedMemberRebaseStrategizer();
        
            var strategizer = new RebaseStrategizer(
                                        memberStrategizer,
                                        x => {
                                            x.AddRoot(subject.Root, Expression.Parameter(SourceType));
                                        });

            return strategizer.GetStrategy(subject.Expression); //need some way to retrieve new roots...
        }


    }
}
