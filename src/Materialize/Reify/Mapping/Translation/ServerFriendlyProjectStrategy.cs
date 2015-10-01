using AutoMapper;
using System;
using System.Linq;
using System.Linq.Expressions;
using Materialize.Expressions;

namespace Materialize.Reify.Mapping.Translation
{
    class ServerFriendlyProjectStrategy<TOrig, TDest>
        : StrategyBase<TOrig, TDest>
    {
        MapContext _ctx;
        LambdaExpression _exProject;
        
        public ServerFriendlyProjectStrategy(MapContext ctx, TypeMap typeMap) 
        {
            _ctx = ctx;
            _exProject = typeMap.CustomProjection;            
        }

        public override Type FetchType {
            get { return typeof(TDest); }
        }
        
        public override IModifier CreateModifier() {
            return new Mapper(_exProject);
        }
        


        class Mapper : MapperModifier<TOrig, TDest, TDest>
        {
            LambdaExpression _exProject;

            public Mapper(LambdaExpression exProject) {
                _exProject = exProject;
            }

            public override Expression Rewrite(Expression exSource) {
                return _exProject.Body.Replace(
                                        _exProject.Parameters.First(), 
                                        exSource);                           
            }

            protected override TDest Transform(TDest obj) {
                //nothing to do here, as server-side projection should give us correct type
                return obj;
            }
        }


    }
    
}
