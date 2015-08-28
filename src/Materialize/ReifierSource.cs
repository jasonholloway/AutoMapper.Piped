using Materialize.Strategies.Projection;
using Materialize.Strategies.PropertyMapping;
using Materialize.Strategies.Direct;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;

namespace Materialize
{
    class ReifierSource
    {
        public static readonly ReifierSource Default = new ReifierSource();

        ConcurrentDictionary<ReifySpec, IReifyStrategy> _dFacs
            = new ConcurrentDictionary<ReifySpec, IReifyStrategy>(ReifySpecEqualityComparer.Default);

        IReifyRule[] _rules;


        public ReifierSource() {
            _rules = new IReifyRule[] {
                new ProjectionRule(),
                new PropertyMapRule(),
                new DirectRule()
            };
        }
        
                
        public IReifier GetReifier(Type tOrig, Type tDest) 
        {
            var strategy = GetStrategy(tOrig, tDest);            
            return strategy.CreateReifier();
        }


        public IReifyStrategy GetStrategy(Type tOrig, Type tDest) 
        {
            var ctx = new ReifyContext(
                            this,
                            new ReifySpec(tOrig, tDest));
            
            return _dFacs.GetOrAdd(ctx.Spec, _ => ResolveStrategy(ctx));
        }


        IReifyStrategy ResolveStrategy(ReifyContext ctx) {            
            foreach(var rule in _rules) {
                var fac = rule.DeduceStrategy(ctx);
                if(fac != null) return fac;
            }

            throw new InvalidOperationException();
        }

    }
}
