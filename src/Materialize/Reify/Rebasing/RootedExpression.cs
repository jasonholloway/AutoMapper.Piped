using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Materialize.Reify.Rebasing
{
    class RootedExpression
    {
        public readonly ParameterExpression Root;
        public readonly Expression Expression;

        public RootedExpression(ParameterExpression exRoot, Expression exSubject) {
            Root = exRoot;
            Expression = exSubject;
        }



        public LambdaExpression ToLambda() {
            return Expression.Lambda(
                                typeof(Func<,>)
                                        .MakeGenericType(Root.Type, Expression.Type),
                                Expression,
                                Root
                                );
        }

        public static RootedExpression FromLambda(LambdaExpression exLambda) {
            return new RootedExpression(
                            exLambda.Parameters.Single(),
                            exLambda.Body);
        }


    }
}
