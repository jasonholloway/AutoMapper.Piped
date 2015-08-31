﻿using AutoMapper;
using JH.DynaType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Materialize.Strategies.Projection
{
    class FullFetchAndProjectStrategy<TOrig, TDest>
        : ReifyStrategyBase<TOrig, TDest>
    {
        ReifyContext _ctx;
        Func<TOrig, TDest> _fnProject;
        
        public FullFetchAndProjectStrategy(ReifyContext ctx, TypeMap typeMap) 
        {
            //no intermediate tuple: just return the full type, and project from it to the destination type, please

            _ctx = ctx;
            _fnProject = (Func<TOrig, TDest>)typeMap.CustomProjection.Compile();
        }


        public override bool UsesIntermediateType {
            get { return false; }
        }


        public override IReifier<TOrig, TDest> CreateReifier() {
            return new Reifier(_ctx, _fnProject);
        }

        
        class Reifier : ReifierBase<TOrig, TOrig, TDest>
        {
            ReifyContext _ctx;
            Func<TOrig, TDest> _fnProject;

            public Reifier(ReifyContext ctx, Func<TOrig, TDest> fnProject) {
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
