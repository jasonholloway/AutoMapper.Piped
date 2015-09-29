using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Materialize.Reify.Parsing
{
    class RootedExpression
    {
        public readonly ParameterExpression[] Roots;
        public readonly Expression Expression;

        public RootedExpression(ParameterExpression[] rexRoots, Expression exSubject) {
            Roots = rexRoots;
            Expression = exSubject;
        }
        
        //public LambdaExpression ToLambda() {
        //    return Expression.Lambda(
        //                        typeof(Func<,>)
        //                                .MakeGenericType(Root.Type, Expression.Type),
        //                        Expression,
        //                        Root
        //                        );
        //}

        public static RootedExpression FromLambda(LambdaExpression exLambda) {
            return new RootedExpression(
                            exLambda.Parameters.ToArray(),
                            exLambda.Body);
        }


    }
}
