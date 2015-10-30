using Materialize.Reify2.Transitions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Materialize.Reify2.Compiling
{   

    internal static class Schematizer {

        public static Scheme Schematize(ITransition op) {
            var sourceOp = op as SourceTransition;

            if(sourceOp == null) {
                throw new InvalidOperationException("Compilation must begin from source element");
            }

            return Schematize(null, (SourceTransition)op);
        }


        static Scheme Schematize(Scheme inpScheme, SourceTransition op) 
        {
            //need to seed scheme with iqueryable parameter
            //but scheme itself has the param map!

            //this is something of an issue, as we no longer have the canonical expression tree at hand (was wasted in parsing)
            //seems that the building of the param map should be done at the beginning, as part of parsing...


            var scheme = new QueryScheme();

            

            return scheme;
        }


        static Scheme Schematize(Scheme prevScheme, FetchTransition op) {
            throw new NotImplementedException();
        }

    }

       
        
}
