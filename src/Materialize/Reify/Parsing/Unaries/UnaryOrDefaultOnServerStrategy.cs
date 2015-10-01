using Materialize.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;


namespace Materialize.Reify.Parsing.Unaries
{
    class UnaryOrDefaultOnServerStrategy<TElem> 
        : QueryableMethodStrategy<IEnumerable<TElem>, TElem>
    {
        MethodInfo _mUnaryDef;

        public UnaryOrDefaultOnServerStrategy(IParseStrategy upstreamStrategy, MethodInfo mUnaryDef)
            : base(upstreamStrategy) 
        {
            FetchType = UpstreamStrategy.FetchType.GetEnumerableElementType();


            _mUnaryDef = mUnaryDef;
            throw new NotImplementedException();

            //Special behaviour needed!
            //Shouldn't pass server's default through mapping...
            //ALWAYS expect default of destination type

            //Can server return DBNull to signal this?
            //...
        }
                

        protected override IModifier Parse(IModifier upstreamMod, MethodCallExpression ex) 
        {
            return new Modifier(upstreamMod, _mUnaryDef);
        }
        


        class Modifier : ParseModifier<IEnumerable<TElem>, TElem>
        {
            MethodInfo _mUnaryDef;

            public Modifier(IModifier upstreamMod, MethodInfo mUnaryDef)
                : base(upstreamMod) 
            {
                _mUnaryDef = mUnaryDef;
            }
            

            protected override Expression Rewrite(Expression exSourceQuery) 
            {
                var exInst = UpstreamRewrite(exSourceQuery);

                var mUnary = _mUnaryDef.MakeGenericMethod(
                                                exInst.Type.GetEnumerableElementType());

                return Expression.Call(mUnary, exInst);
            }


            protected override TElem Transform(object fetched) 
            {
                var rFetched = Array.CreateInstance(fetched.GetType(), 1);
                rFetched.SetValue(fetched, 0);

                var transformed = UpstreamTransform(rFetched);
                
                return transformed.Single();
            }
        }

    }
}
