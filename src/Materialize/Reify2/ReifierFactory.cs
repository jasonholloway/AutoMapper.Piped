using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Materialize.Expressions;
using Materialize.Reify2.Parameterize;
using Materialize.Reify2.Compiling;
using Materialize.Types;
using Materialize.Reify2.Parsing2;

namespace Materialize.Reify2
{
    class ReifierFactory
    {

        public Reifier Build(Expression exQuery, ReifyContext ctx, Expression exBase) 
        {

            var m = QyMethods.Aggregate;



            var exCanonical = CanonicalizeQuery(exQuery, exBase);

            var subject = new ParseSubject(
                                    exCanonical,
                                    ctx);
            
            var transitions = Parser.ParseAndPackage(subject);


            //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
            //OPTIMIZE HERE!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
            //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!


            var paramMap = ParamMapFactory.Build(exCanonical);

            var scheme = Schematizer.Schematize(transitions, paramMap);
            var executor = scheme.Compile();

            return new Reifier(exCanonical, paramMap, executor);
        }





        static Expression CanonicalizeQuery(Expression exQuery, Expression exBase) {
            return exQuery.Replace(
                            x => x is ConstantExpression || x == exBase,
                            x => Expression.Constant(x.Type.GetDefaultValue(), x.Type));
        }
                
    }
}
