using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Materialize.Expressions;
using Materialize.Reify2.Parameterize;
using Materialize.Reify2.Compile;
using Materialize.Types;
using Materialize.Reify2.Parse;
using Materialize.Reify2.Transitions;

namespace Materialize.Reify2
{
    static class ReifierFactory
    {

        public static Reifier Build(Expression exQuery, ReifyContext ctx, Expression exBase) 
        {
            var exCanonical = CanonicalizeQuery(exQuery, exBase);

            var subject = new ParseSubject(
                                    exCanonical,
                                    ctx);
            
            var transitions = Parser.ParseAndPackage(subject);
            ctx.Snooper?.Event("Transitions", (IEnumerable<Transition>)transitions); //each rearrangement stage should publish its results


            //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
            //OPTIMIZE HERE!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
            //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!



            var paramMap = ParamMapFactory.Build(exCanonical);
            
            var scheme = Schematizer.Schematize(ctx, transitions, paramMap);

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
