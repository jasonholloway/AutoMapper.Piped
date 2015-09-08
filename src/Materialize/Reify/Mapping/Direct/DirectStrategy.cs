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
        MapContext _ctx;

        public DirectStrategy(MapContext ctx) {
            _ctx = ctx;
        }

        public override Type FetchedType {
            get { return typeof(TDest); }
        }

        public override IModifier CreateModifier() {
            return new Mapper(_ctx);
        }


        class Mapper : MapperModifier<TOrig, TDest>
        {
            MapContext _ctx;

            public Mapper(MapContext ctx) {
                _ctx = ctx;
            }

            protected override Expression RewriteSingle(Expression exOrig) {
                return exOrig;
            }

            protected override TDest TransformSingle(TDest orig) {
                return orig;
            }
        }
    }


}
