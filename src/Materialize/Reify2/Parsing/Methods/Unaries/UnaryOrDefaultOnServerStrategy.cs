using Materialize.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;


namespace Materialize.Reify2.Parsing.Methods.Unaries
{
    class UnaryOrDefaultOnServerStrategy<TElem> 
        : MethodStrategyBase<IEnumerable<TElem>, TElem>
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


            protected override Expression ServerFilter(Expression exQuery) {
                throw new NotImplementedException();
                return base.ServerFilter(exQuery);
            }

            protected override Expression ServerProject(Expression exQuery) {
                throw new NotImplementedException();
                return base.ServerProject(exQuery);
            }

            protected override Expression ClientTransform(Expression exTransform) {
                throw new NotImplementedException();
                return base.ClientTransform(exTransform);
            }



            //protected override Expression FetchMod(Expression exSourceQuery) 
            //{
            //    var exInst = UpstreamFetchMod(exSourceQuery);

            //    var mUnary = _mUnaryDef.MakeGenericMethod(
            //                                    exInst.Type.GetEnumerableElementType());

            //    return Expression.Call(mUnary, exInst);
            //}



            //protected override Expression TransformMod(Expression exQuery) {
            //    throw new NotImplementedException();
            //}



            //protected override TElem Transform(object fetched) 
            //{
            //    var rFetched = Array.CreateInstance(fetched.GetType(), 1);
            //    rFetched.SetValue(fetched, 0);

            //    var transformed = UpstreamTransform(rFetched);
                
            //    return transformed.Single();
            //}
        }

    }
}
