using Materialize.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Materialize.Reify.Rebasing.Methods.Rules
{
    class EnumerableUnaryRule : LinqMethodRule
    {
        public EnumerableUnaryRule() 
            : base(new[] {
                    EnumerableMethods.AnyDef,
                    EnumerableMethods.CountDef
                }) 
            { }


        protected override IRebaseStrategy CreateStrategy(LinqMethodContext ctx) 
        {
            var upstreamStrategy = ctx.UpstreamStrategy;
                        
            var mRebased = ctx.MethodDef.MakeGenericMethod(ctx.RebasedElemType);

            return UnrootedStrategy(
                        new TypeVector(ctx.CallExp.Type, mRebased.ReturnType),
                        (MethodCallExpression ex) => {
                            return Expression.Call(
                                                mRebased,
                                                upstreamStrategy.Rebase(ex.Arguments[0])
                                                );
                        });
        }



    }
}
