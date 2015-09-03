using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Materialize.Strategies.Direct
{
    class DirectStrategy<TOrig, TDest>
        : StrategyBase<TOrig, TDest>
    {
        Context _ctx;

        public DirectStrategy(Context ctx) {
            _ctx = ctx;
        }

        public override Type ProjectedType {
            get { return typeof(TDest); }
        }

        public override IReifier<TOrig, TDest> CreateReifier() {
            return new Reifier(_ctx);
        }


        class Reifier : ReifierBase<TOrig, TDest>
        {
            Context _ctx;

            public Reifier(Context ctx) {
                _ctx = ctx;
            }

            protected override Expression ProjectSingle(Expression exOrig) {
                return exOrig;
            }

            protected override TDest TransformSingle(TDest orig) {
                return orig;
            }
        }
    }


}
