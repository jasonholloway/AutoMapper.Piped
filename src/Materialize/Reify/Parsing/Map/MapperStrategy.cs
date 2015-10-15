using Materialize.Reify.Mapping;
using Materialize.Reify.Rebasing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;


namespace Materialize.Reify.Parsing.Map
{
    /// <summary>
    /// Wraps tree of MapStrategies into a ParseStrategy
    /// </summary>
    class MapperStrategy
        : ReifyStrategy, IParseStrategy
    {
        IMapStrategy _mapStrategy;

        public MapperStrategy(IMapStrategy mapStrategy) {
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

        
        public IRebaseStrategy GetRebaseStrategy(RebaseSubject subject) 
        {
            var strategizer = new RebaseStrategizer(
                                    x => {
                                        foreach(var rv in subject.RootVectors) {
                                            x.AddRootStrategy(
                                                    rv.OrigRoot,
                                                    _mapStrategy.GetRootRebaseStrategy(rv));
                                        }
                                    });
            
            return strategizer.Strategize(subject.Expression);
        }



        public override IEnumerable<IReifyStrategy> UpstreamStrategies {
            get {
                return new IReifyStrategy[] { _mapStrategy };
            }
        }
        
    }
}
