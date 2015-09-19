using AutoMapper;
using JH.DynaType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Materialize.Reify.Mapping.Translation
{
    class FullFetchAndTransformStrategy<TOrig, TDest>
        : StrategyBase<TOrig, TDest>
    {
        MapContext _ctx;
        Func<TOrig, TDest> _fnTransform;
        
        public FullFetchAndTransformStrategy(MapContext ctx, TypeMap typeMap) 
        {
            //no intermediate tuple: just return the full type, and project from it to the destination type, please

            _ctx = ctx;
            _fnTransform = (Func<TOrig, TDest>)typeMap.CustomProjection.Compile();
        }

        public override Type FetchType {
            get { return typeof(TOrig); }
        }

        public override bool RewritesExpression {
            get { return false; }
        }

        public override IModifier CreateModifier() {
            return new Mapper(_ctx, _fnTransform);
        }

        
        class Mapper : MapperModifier<TOrig, TOrig, TDest>
        {
            MapContext _ctx;
            Func<TOrig, TDest> _fnTransform;

            public Mapper(MapContext ctx, Func<TOrig, TDest> fnTransform) {
                _ctx = ctx;
                _fnTransform = fnTransform;
            }
            
            public override Expression Rewrite(Expression exSource) {
                return exSource;
            }
            
            protected override TDest Transform(TOrig fetched) {
                return _fnTransform(fetched);
            }

        }




    }

}
