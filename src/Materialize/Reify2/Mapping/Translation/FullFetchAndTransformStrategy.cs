using AutoMapper;
using JH.DynaType;
using Materialize.Expressions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Materialize.Reify2.Mapping.Translation
{
    class FullFetchAndTransformStrategy<TOrig, TDest>
        : MapStrategyBase<TOrig, TDest>
    {
        MapContext _ctx;
        Expression<Func<TOrig, TDest>> _exProjection;
        
        public FullFetchAndTransformStrategy(MapContext ctx, TypeMap typeMap) 
        {
            _ctx = ctx;
            _exProjection = (Expression<Func<TOrig, TDest>>)typeMap.CustomProjection;
        }

        public override Type FetchType {
            get { return typeof(TOrig); }
        }

        public override bool RewritesExpression {
            get { return false; }
        }

        public override IModifier CreateModifier() {
            return new Mapper(_ctx, _exProjection);
        }

        
        class Mapper : MapperModifier<TOrig, TOrig, TDest>
        {
            MapContext _ctx;
            Expression<Func<TOrig, TDest>> _exProjection;

            public Mapper(MapContext ctx, Expression<Func<TOrig, TDest>> exProjection) {
                _ctx = ctx;
                _exProjection = exProjection;
            }


            protected override Expression ClientTransform(Expression exTransform) {
                return _exProjection.Body.Replace(
                                            _exProjection.Parameters.Single(),
                                            exTransform);
            }




            //protected override Expression FetchMod(Expression exSource) {
            //    return exSource;
            //}


            //protected override Expression TransformMod(Expression exFetched) {
            //    return _exProjection.Body.Replace(
            //                                _exProjection.Parameters.Single(),
            //                                exFetched);
            //}


            //protected override TDest Transform(TOrig fetched) {
            //    throw new NotImplementedException();
            //    //return _fnTransform(fetched);
            //}

        }




    }

}
