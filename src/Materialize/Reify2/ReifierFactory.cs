using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Materialize.Expressions;
using Materialize.Reify2.Params;
using Materialize.Reify2.Compiling;
using Materialize.Types;

namespace Materialize.Reify2
{
    class ReifierFactory
    {

        public Reifier Build(Expression exQuery, ReifyContext ctx) 
        {            
            var exCanonical = CanonicalizeQuery(exQuery);
            
            var parameterized = Parameterizer.Parameterize(exCanonical);








            

            return new Reifier(exCanonical, a => null);
        }





        static Expression CanonicalizeQuery(Expression exQuery) {
            return exQuery.Replace(
                            x => x is ConstantExpression,
                            x => Expression.Constant(x.Type.GetDefaultValue(), x.Type));
        }
                
    }
}
