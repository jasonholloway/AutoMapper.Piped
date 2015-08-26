using System;
using System.Linq.Expressions;

namespace Materialize.Rules
{
    class DirectRule : IReifyRule
    {        
        public IReifierFactory BuildFactoryIfApplicable(ReifySpec spec) {
            if(spec.SourceType == spec.DestType) {
                var facType = typeof(DirectFactory<,>).MakeGenericType(spec.SourceType, spec.DestType);
                return (IReifierFactory)Activator.CreateInstance(facType);
            }

            return null;
        }
    }
    

    class DirectFactory<TOrig, TDest>
        : ReifierFactory<TOrig, TDest>
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

        public Expression VisitExpression(Expression exOrig) {
            return exOrig;
        }

        public object VisitFetchedNode(object orig) {
            return orig;
        }
    }



}
