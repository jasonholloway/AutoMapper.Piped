using AutoMapper;
using JH.DynaType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Materialize.Reify.Modifiers;

namespace Materialize.Reify.Mapping.CustomProject
{
    class FullFetchAndTransformStrategy<TOrig, TDest>
        : StrategyBase<TOrig, TDest>
    {
        Context _ctx;
        Func<TOrig, TDest> _fnMap;
        
        public FullFetchAndTransformStrategy(Context ctx, TypeMap typeMap) 
        {
            //no intermediate tuple: just return the full type, and project from it to the destination type, please

            _ctx = ctx;
            _fnMap = (Func<TOrig, TDest>)typeMap.CustomProjection.Compile();
        }

        public override Type ProjectedType {
            get { return typeof(TOrig); }
        }


        public override IModifier CreateModifier() {
            return new Mapper(_ctx, _fnMap);
        }

        
        class Mapper : MapperBase<TOrig, TOrig, TDest>
        {
            Context _ctx;
            Func<TOrig, TDest> _fnProject;

            public Mapper(Context ctx, Func<TOrig, TDest> fnProject) {
                _ctx = ctx;
                _fnProject = fnProject;
            }

            protected override Expression ProjectSingle(Expression exSource) {
                return exSource;
            }
            
            protected override TDest TransformSingle(TOrig source) {
                return _fnProject(source);
            }
        }




    }

}
