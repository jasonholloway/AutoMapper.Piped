using AutoMapper;
using System;
using System.Linq;
using System.Linq.Expressions;
using Materialize.Expressions;
using Materialize.Reify.Rebasing;

namespace Materialize.Reify.Mapping.Translation
{
    class ServerFriendlyProjectStrategy<TOrig, TDest>
        : MapStrategyBase<TOrig, TDest>
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

        
        public override IRebaseStrategy GetRootRebaseStrategy(RootVector roots) 
        {
            //generally shouldn't be able to rebase.

            //only if very simple, reversible projection.

            //should however return much better errors...



            return base.GetRootRebaseStrategy(roots);
                                  
            //return new RootRebaseStrategy<TDest, TOrig>(ex => roots.RebasedRoot);
        }


    }
    
}
