using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Materialize.Reify.Rebasing;

namespace Materialize.Reify.Mapping.Direct
{
    /// <summary>
    /// No mapping required: value is transferred directly
    /// </summary>
    class DirectStrategy<TOrig, TDest>
        : MapStrategyBase<TOrig, TDest>
        where TOrig : TDest
    {
        MapContext _ctx;

        public DirectStrategy(MapContext ctx) {
            _ctx = ctx;
        }

        public override Type FetchType {
            get { return typeof(TDest); }
        }

        public override bool RewritesExpression {
            get { return false; }
        }
        
        public override IModifier CreateModifier() {
            return new Mapper(_ctx);
        }


        class Mapper : MapperModifier<TOrig, TOrig, TDest>
        {
            MapContext _ctx;

            public Mapper(MapContext ctx) {
                _ctx = ctx;
            }

            //protected override Expression FetchMod(Expression exOrig) {
            //    return exOrig;
            //}
            
            //protected override Expression TransformMod(Expression exFetched) {
            //    return exFetched;
            //}




            //protected override TDest Transform(TOrig fetched) {
            //    return (TDest)fetched;
            //}
        }


        public override IRebaseStrategy GetRootRebaseStrategy(RootVector roots) {
            return new RootRebaseStrategy<TDest, TOrig>(ex => roots.RebasedRoot);
        }
    }


}
