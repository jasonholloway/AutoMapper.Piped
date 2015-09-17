using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;


namespace Materialize.Reify.Parsing.Limiters
{   
    class ServerSideLimiterStrategy<TElem> 
        : QueryableMethodStrategy
    {
        MethodInfo _mLimiterDef;

        public ServerSideLimiterStrategy(IParseStrategy upstreamStrategy, MethodInfo mLimiterDef)
            : base(upstreamStrategy) 
        {
            _mLimiterDef = mLimiterDef;
        }
     

        protected override IModifier Parse(IModifier upstreamMod, MethodCallExpression ex) 
        {
            var count = (int)((ConstantExpression)ex.Arguments[1]).Value;

            return new Modifier(upstreamMod, _mLimiterDef, count);
        }
        


        class Modifier : ParseModifier<IEnumerable<TElem>, IEnumerable<TElem>>
        {
            MethodInfo _mLimiterDef;
            int _count;

            public Modifier(IModifier upstreamMod, MethodInfo mLimiterDef, int count)
                : base(upstreamMod) 
            {
                _mLimiterDef = mLimiterDef;
                _count = count;
            }
            

            protected override Expression Rewrite(Expression exSourceQuery) 
            {
                var exInst = UpstreamRewrite(exSourceQuery);

                var mLimiter = _mLimiterDef.MakeGenericMethod(
                                            exInst.Type.GetEnumerableElementType());

                return Expression.Call(
                                    mLimiter, 
                                    exInst, 
                                    Expression.Constant(_count));
            }


            protected override IEnumerable<TElem> Transform(object fetched) 
            {
                return UpstreamTransform(fetched);
            }
        }

    }
}
