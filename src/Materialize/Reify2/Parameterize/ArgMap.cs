using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Materialize.Reify2.Parameterize
{
    internal class ArgMap
    {
        ParamMap _paramMap;
        Expression _exQuery;

        protected ArgMap() { }
        
                
        public virtual Expression GetIncidentalWith(NodeAccessor accessor) {
            return accessor(_exQuery);
        }
                

        public virtual Expression GetIncidentalFor(Expression exCanonical) 
        {
            var accessor = _paramMap.TryGetAccessor(exCanonical);

            if(accessor != null) {
                return GetIncidentalWith(accessor);
            }

            throw new InvalidOperationException();
        }




        public virtual object GetValueWith(NodeAccessor accessor) 
        {
            var exIncidental = GetIncidentalWith(accessor);
            
            var exConstant = exIncidental as ConstantExpression;

            if(exConstant != null) {
                return exConstant.Value;
            }

            throw new InvalidOperationException();
        }


        public virtual object GetValueFor(Expression exCanonical) 
        {
            var accessor = _paramMap.TryGetAccessor(exCanonical);

            if(accessor != null) {
                return GetValueWith(accessor);
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
