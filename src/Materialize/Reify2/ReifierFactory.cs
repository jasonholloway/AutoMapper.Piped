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
using Materialize.Reify2.Parsing2;

namespace Materialize.Reify2
{
    class ReifierFactory
    {

        public Reifier Build(Expression exQuery, ReifyContext ctx) 
        {            
            var exCanonical = CanonicalizeQuery(exQuery);
            
            var paramMap = ParamMapFactory.Build(exCanonical);


            //NOW HYDRATE ARGMAP (for benefit of parser...)
            var argMap = ArgMap.Create(paramMap, exQuery);
            







            //though argmap should only hydrate on-demand...(?)
            //nah, except for this occasion, all values will surely always be needed
            
            
                        
            //Parameterizer shouldn't emplace parameters... it should just build a ParamMap
            //*BUT* need some nice, non-dictionary way to get arg values for encountered parameterized constants.
            //Can't be strong references, as different ArgMap instances will be used concurrently,
            //against shared base, potentially.

            //Some kind of indirection via index in order. A dictionary keyed by ConstantExpression ref.

            //SO: Parameterizer not needed; just a ParamMap factory instead.



            //now, need to parse

            //an IQueryable constant should be parsed as a source element
            //but the parser should also extract information from it...
            //yet it has been canonicalized! ie stripped of info.

            //sourceregime needs determining before parsing, then.
            //alternatives? The constant value must be in place for that...
            //All constants will be hydrated via the ArgMap, which will extract values from the query at hand.
            //The concrete queryable could then be requested on first parse...
            //Maybe I like this idea! Keeps things light up front.

            //SO: 




            //Parser.ParseAndPackage();


            

            return new Reifier(exCanonical, a => null);
        }





        static Expression CanonicalizeQuery(Expression exQuery) {
            return exQuery.Replace(
                            x => x is ConstantExpression,
                            x => Expression.Constant(x.Type.GetDefaultValue(), x.Type));
        }
                
    }
}
