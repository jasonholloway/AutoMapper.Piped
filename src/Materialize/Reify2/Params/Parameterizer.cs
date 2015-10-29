using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Materialize.Expressions;

namespace Materialize.Reify2.Params
{
    internal static class Parameterizer
    {

        public static Expression Parameterize(ParameterMap map, Expression subject) {
            return subject.Replace(
                            x => x is ConstantExpression, 
                            x => {
                                //register route with map, somehow...

                                return x;
                            });
        }


    }
}
