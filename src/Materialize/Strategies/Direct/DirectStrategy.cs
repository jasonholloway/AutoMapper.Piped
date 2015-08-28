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
        ReifyContext _ctx;

        public DirectStrategy(ReifyContext ctx) {
            _ctx = ctx;
        }

        public override bool UsesIntermediateType {
            get { return false; }
        }

        public override IReifier<TOrig, TDest> CreateReifier() {
            return new Reifier(_ctx);
        }


        class Reifier : ReifierBase<TOrig, TDest>
        {
            ReifyContext _ctx;

            public Reifier(ReifyContext ctx) {
                _ctx = ctx;
            }

            protected override Expression MapSingle(Expression exOrig) {
                return exOrig;
            }

            protected override TDest ReformSingle(TDest orig) {
                return orig;
            }
        }
    }


}
