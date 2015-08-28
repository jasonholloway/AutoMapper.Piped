using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Materialize.Strategies.Direct
{
    class DirectStrategy<TOrig, TDest>
        : ReifierStrategy<TOrig, TDest>
    {
        public override bool UsesIntermediateType {
            get { return false; }
        }

        public override IReifier<TOrig, TDest> CreateReifier(ReifyContext ctx) {
            return new Reifier(ctx);
        }


        class Reifier : IReifier<TOrig, TDest>
        {
            ReifyContext _ctx;

            public Reifier(ReifyContext ctx) {
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


}
