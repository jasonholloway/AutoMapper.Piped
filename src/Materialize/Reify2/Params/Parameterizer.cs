using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Materialize.Expressions;
using System.Collections.Concurrent;

namespace Materialize.Reify2.Params
{
    

    internal static class Parameterizer
    {        
        
        public static Parameterized Parameterize(Expression subject) 
        {
            var map = new ParamMap();
            
            var exNew = subject.Replace(
                            x => x is ConstantExpression, 
                            x => {
                                var param = Expression.Parameter(x.Type);

                                map.Add(param);

                                return param;
                            });

            exNew.ForEach(
                    (ex, path) => {
                        var param = ex as ParameterExpression;

                        if(param != null) {
                            map.TryModify(param, i => i.Accessor = path.GetAccessor());
                        }
                    });
            
            return new Parameterized(exNew, map);
        }



        public struct Parameterized
        {
            public readonly Expression Expression;
            public readonly ParamMap Map;

            public Parameterized(Expression ex, ParamMap map) {
                Expression = ex;
                Map = map;
            }
        }


    }
}
