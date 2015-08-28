using System;
using System.Linq.Expressions;

namespace Materialize.Rules
{
    class DirectRule : IReifyRule
    {        
        public IReifyStrategy ResolveStrategy(ReifySpec spec) {
            if(spec.SourceType == spec.DestType) {
                var strategyType = typeof(DirectStrategy<,>).MakeGenericType(spec.SourceType, spec.DestType);
                return (IReifyStrategy)Activator.CreateInstance(strategyType);
            }

            return null;
        }
    }
    

    class DirectStrategy<TOrig, TDest>
        : ReifierStrategy<TOrig, TDest>
    {
        //build up important info here, to feed to reifier instances; factories will be cached
        //...

        public override IReifier<TOrig, TDest> CreateReifier(ReifyContext ctx) {
            return new DirectReifier<TOrig, TDest>(ctx);
        }
    }


    class DirectReifier<TOrig, TDest>
        : IReifier<TOrig, TDest>
    {
        ReifyContext _ctx;

        public DirectReifier(ReifyContext ctx) {
            _ctx = ctx;
        }

        public Expression Map(Expression exOrig) {
            return exOrig;
        }

        public object Reform(object orig) {
            return orig;
        }
    }



}
