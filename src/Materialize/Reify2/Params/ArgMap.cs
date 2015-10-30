using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Materialize.Reify2.Params
{
    internal class ArgMap
    {
        ParamMap _paramMap;
        Expression _exQuery;

        protected ArgMap() { }
                

        public virtual Expression GetIncidentalFor(Expression exCanonical) 
        {
            var accessor = _paramMap.TryGetAccessor(exCanonical);

            if(accessor != null) {
                return accessor(_exQuery);
            }

            throw new InvalidOperationException();
        }


        public object GetValueFor(Expression exCanonical) 
        {
            var exIncidental = GetIncidentalFor(exCanonical);

            var exConstant = exIncidental as ConstantExpression;

            if(exConstant != null) {
                return exConstant.Value;
            }

            throw new InvalidOperationException();
        }




        public static ArgMap Create(ParamMap paramMap, Expression exQuery) 
        {
            var argMap = new ArgMap();

            argMap._paramMap = paramMap;
            argMap._exQuery = exQuery;
            
            return argMap;
        }



    }
}
