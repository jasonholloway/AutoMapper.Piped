﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using Materialize.Types;


namespace Materialize.Reify.Parsing.Methods.Unaries
{
    class UnaryOnServerStrategy<TElem> 
        : MethodStrategyBase<IEnumerable<TElem>, TElem>
    {
        MethodInfo _mUnary;
        
        public UnaryOnServerStrategy(IParseStrategy upstreamStrategy, MethodInfo mUnaryDef)
            : base(upstreamStrategy) 
            {
                FetchType = UpstreamStrategy.FetchType.GetEnumerableElementType();
                _mUnary = mUnaryDef.MakeGenericMethod(FetchType);
            }

        
        protected override IModifier Parse(IModifier upstreamMod, MethodCallExpression ex) 
        {
            return new Modifier(upstreamMod, _mUnary);
        }
        


        class Modifier : ParseModifier<IEnumerable<TElem>, TElem>
        {
            MethodInfo _mUnary;

            public Modifier(IModifier upstreamMod, MethodInfo mUnary)
                : base(upstreamMod) 
            {
                _mUnary = mUnary;
            }
            

            protected override Expression FetchMod(Expression exSourceQuery) 
            {
                var exInst = UpstreamFetchMod(exSourceQuery);
                
                return Expression.Call(_mUnary, exInst);
            }


            protected override Expression TransformMod(Expression exQuery) {
                throw new NotImplementedException();
            }


            protected override TElem Transform(object fetched) { 
                //need to package in enumerable to pass upstream
                var rFetched = Array.CreateInstance(fetched.GetType(), 1);
                rFetched.SetValue(fetched, 0);

                var transformed = UpstreamTransform(rFetched);
                
                return transformed.Single();
            }
        }

    }
}
