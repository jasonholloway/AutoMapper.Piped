using Materialize.Strategies.Projection;
using Materialize.Strategies.PropertyMapping;
using Materialize.Strategies.Direct;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using Materialize.Strategies;
using Materialize.Projection;

namespace Materialize.Strategies
{
    class StrategySource
    {
        public static readonly StrategySource Default = new StrategySource();

        ConcurrentDictionary<TypeVector, IStrategy> _dStrategies
            = new ConcurrentDictionary<TypeVector, IStrategy>(TypeVectorEqualityComparer.Default);

        IRule[] _rules;

        InputSpecSource _inputSpecSource = new InputSpecSource();
        ProjectedTypeBuilder _projTypeBuilder = new ProjectedTypeBuilder();


        public StrategySource() {
            _rules = new IRule[] {
                new CustomMapRule(),
                new PropertyMapRule(),
                new DirectRule()
            };
        }
        
                
        //public IReifier GetReifier(Type tOrig, Type tDest) 
        //{
        //    var strategy = GetStrategy(tOrig, tDest);            
        //    return strategy.CreateReifier();
        //}



        //public IReifyStrategy GetStrategy(ReifyContext ctx) {
        //    return _dStrategies.GetOrAdd(ctx.TypeVector, _ => ResolveStrategy(ctx));
        //}

        public IStrategy GetStrategy(Type tOrig, Type tDest) {
            var ctx = ContextFactory.Default.CreateContext(tOrig, tDest);
            
            return _dStrategies.GetOrAdd(ctx.TypeVector, _ => ResolveStrategy(ctx));
        }


        IStrategy ResolveStrategy(Context ctx) {            
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
