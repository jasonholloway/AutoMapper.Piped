using Materialize.Reify.Mapping.CustomProject;
using Materialize.Reify.Mapping.PropertyMaps;
using Materialize.Reify.Mapping.Direct;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using Materialize.Projection;

namespace Materialize.Reify.Mapping
{
    class StrategyProvider
    {
        public static readonly StrategyProvider Default = new StrategyProvider();

        ConcurrentDictionary<TypeVector, IStrategy> _dStrategies
            = new ConcurrentDictionary<TypeVector, IStrategy>(TypeVectorEqualityComparer.Default);

        InputSpecSource _inputSpecSource = new InputSpecSource();
        ProjectedTypeBuilder _projTypeBuilder = new ProjectedTypeBuilder();

        IRule[] _rules = new IRule[] {
                            new CustomProjectRule(),
                            new PropertyMapRule(),
                            new DirectRule()
                        };
        

        public IStrategy GetStrategy(Type tOrig, Type tDest) {
            var ctx = ContextFactory.Default.CreateContext(tOrig, tDest);
            
            return _dStrategies.GetOrAdd(
                                    ctx.TypeVector, 
                                    _ => PlanStrategy(ctx));
        }


        IStrategy PlanStrategy(Context ctx) {            
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
