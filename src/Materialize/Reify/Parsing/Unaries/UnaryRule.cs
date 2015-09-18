﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Materialize.Reify.Parsing.Unaries
{
    class UnaryRule : QueryableMethodRule
    {
        //static IDictionary<MethodInfo, Type> _dStrategies
        //    = new Dictionary<MethodInfo, Type>() {
        //        {
        //            Refl.GetGenMethod(() => Queryable.First<int>(null)),
        //            typeof(FirstStrategy<>)
        //        },
        //        {
        //            Refl.GetGenMethod(() => Queryable.FirstOrDefault<int>(null)),
        //            typeof(FirstOrDefaultStrategy<>)
        //        },
        //    };



        static ISet<MethodInfo> _unaryMethods
            = new HashSet<MethodInfo>(new[] {
                Refl.GetGenMethod(() => Queryable.First<object>(null)),
                Refl.GetGenMethod(() => Queryable.Last<object>(null)),
                Refl.GetGenMethod(() => Queryable.Single<object>(null))
            });

        static ISet<MethodInfo> _unaryOrDefaultMethods
            = new HashSet<MethodInfo>(new[] {
                Refl.GetGenMethod(() => Queryable.FirstOrDefault<object>(null)),
                Refl.GetGenMethod(() => Queryable.LastOrDefault<object>(null)),
                Refl.GetGenMethod(() => Queryable.SingleOrDefault<object>(null)),
            });



        
        public UnaryRule(IParseStrategySource strategySource)
            : base(strategySource) { }
        
        
        public override IParseStrategy GetStrategy(ParseContext ctx) 
        {
            if(ctx.MethodDef != null && ctx.TypeArgs.Length == 1) 
            {
                Type tStrategyGen = null;
                IParseStrategy upstreamStrategy = null;
                
                if(_unaryMethods.Contains(ctx.MethodDef)) 
                {
                    upstreamStrategy = GetUpstreamStrategy(ctx);

                    tStrategyGen = upstreamStrategy.FiltersFetchedSet
                                    ? null //typeof(FirstOnClientStrategy<>)
                                    : typeof(UnaryOnServerStrategy<>);
                }
                    
                if(_unaryOrDefaultMethods.Contains(ctx.MethodDef)) 
                {                    
                    upstreamStrategy = GetUpstreamStrategy(ctx);

                    tStrategyGen = upstreamStrategy.FiltersFetchedSet
                                    ? null
                                    : typeof(UnaryOrDefaultOnServerStrategy<>);
                }

                if(tStrategyGen != null) {
                    var tElem = ctx.TypeArgs.Single();

                    return CreateStrategy(
                                    tStrategyGen.MakeGenericType(tElem),
                                    upstreamStrategy,
                                    ctx.MethodDef);
                }
            }

            return null;
        }
    }
}
