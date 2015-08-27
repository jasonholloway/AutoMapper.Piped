﻿using Materialize.Rules;
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

        ConcurrentDictionary<ReifySpec, IReifierFactory> _dFacs
            = new ConcurrentDictionary<ReifySpec, IReifierFactory>(ReifySpecEqualityComparer.Default);

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
            var factory = GetReifierFactory(tOrig, tDest);

            var ctx = new ReifyContext();

            return factory.CreateReifier(ctx);
        }

        public IReifierFactory GetReifierFactory(Type tOrig, Type tDest) {
            var spec = new ReifySpec(tOrig, tDest);
            return _dFacs.GetOrAdd(spec, s => BuildReifierFactory(s));
        }


        IReifierFactory BuildReifierFactory(ReifySpec spec) {            
            foreach(var rule in _rules) {
                var fac = rule.BuildFactoryIfApplicable(spec);
                if(fac != null) return fac;
            }

            throw new InvalidOperationException();
        }

    }
}
