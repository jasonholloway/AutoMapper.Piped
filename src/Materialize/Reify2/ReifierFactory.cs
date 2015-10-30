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

        public Reifier Build(Expression exQuery, ReifyContext ctx, Expression exBase) 
        {            
            var exCanonical = CanonicalizeQuery(exQuery, exBase);
            
            var paramMap = ParamMapFactory.Build(exCanonical);

            
            var subject = new ParseSubject(
                                    exCanonical,
                                    paramMap.CreateArgMap(exQuery),
                                    ctx);
            
            var transitions = Parser.ParseAndPackage(subject);


            //OPTIMIZE HERE!!!



            //so now need to compile the transitions
            //accumulate a Scheme
            //Compile!

            //how could we test this?
            //given a certain transition list, such or such a functioning Reifier is needed
            //the transition list is complimented by a canonical query form. Information stored within 
            //the transitions relates to this canonical form directly, cannot be separated.
            //And so any tests of compilation will need such a query. Plus some kind of mocked ArgMap to deliver default types.




            //Parser.ParseAndPackage();


            

            return new Reifier(exCanonical, a => null);
        }





        static Expression CanonicalizeQuery(Expression exQuery, Expression exBase) {
            return exQuery.Replace(
                            x => x is ConstantExpression || x == exBase,
                            x => Expression.Constant(x.Type.GetDefaultValue(), x.Type));
        }
                
    }
}
