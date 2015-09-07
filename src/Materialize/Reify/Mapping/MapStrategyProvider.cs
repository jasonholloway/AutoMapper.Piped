using Materialize.Reify.Mapping.CustomProject;
using Materialize.Reify.Mapping.PropertyMaps;
using Materialize.Reify.Mapping.Direct;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using Materialize.ProjectionTypes;

namespace Materialize.Reify.Mapping
{
    class MapStrategyProvider
    {
        public static readonly MapStrategyProvider Default = new MapStrategyProvider();

        ConcurrentDictionary<TypeVector, IMapStrategy> _dStrategies
            = new ConcurrentDictionary<TypeVector, IMapStrategy>(TypeVectorEqualityComparer.Default);

        InputSpecSource _inputSpecSource = new InputSpecSource();
        ProjectedTypeBuilder _projTypeBuilder = new ProjectedTypeBuilder();

        IMapRule[] _rules = new IMapRule[] {
                            new CustomProjectRule(),
                            new PropertyMapRule(),
                            new DirectRule()
                        };
        

        public IMapStrategy GetStrategy(Type tOrig, Type tDest) {
            var ctx = ContextFactory.Default.CreateContext(tOrig, tDest);
            
            return _dStrategies.GetOrAdd(
                                    ctx.TypeVector, 
                                    _ => PlanStrategy(ctx));
        }


        IMapStrategy PlanStrategy(Context ctx) {            
            foreach(var rule in _rules) {
                var fac = rule.DeduceStrategy(ctx);
                if(fac != null) return fac;
            }

            throw new InvalidOperationException();
        }


        public void Reset() {
            _dStrategies.Clear();
        }


    }
}
