using Materialize.Reify.Modifiers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Materialize.Reify.Mapping.Direct
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

        public override IModifier CreateModifier() {
            return new Mapper(_ctx);
        }


        class Mapper : MapperBase<TOrig, TDest>
        {
            Context _ctx;

            public Mapper(Context ctx) {
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
