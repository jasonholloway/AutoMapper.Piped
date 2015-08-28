using Materialize.Rules;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                new EdmCompatibleProjectionRule(this),
                new ProjectionRule(this),
                new PropertyMapRule(this),
                new DirectRule()
            };
        }
                
        public IReifier GetReifier(Type tOrig, Type tDest) 
        {
            var factory = GetStrategy(tOrig, tDest);

            var ctx = new ReifyContext();

            return factory.CreateReifier(ctx);
        }

        public IReifyStrategy GetStrategy(Type tOrig, Type tDest) {
            var spec = new ReifySpec(tOrig, tDest);
            return _dFacs.GetOrAdd(spec, s => ResolveStrategy(s));
        }


        IReifyStrategy ResolveStrategy(ReifySpec spec) {            
            foreach(var rule in _rules) {
                var fac = rule.DeduceStrategy(spec);
                if(fac != null) return fac;
            }

            throw new InvalidOperationException();
        }

    }
}
