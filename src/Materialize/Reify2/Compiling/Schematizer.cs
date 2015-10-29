using Materialize.Reify2.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Materialize.Reify2.Compiling
{   

    internal static class Schematizer {

        public static Scheme Schematize(IOperation op) {
            var sourceOp = op as SourceOp;

            if(sourceOp == null) {
                throw new InvalidOperationException("Compilation must begin from source element");
            }

            return Schematize(null, (SourceOp)op);
        }


        static Scheme Schematize(Scheme inpScheme, SourceOp op) 
        {
            //need to seed scheme with iqueryable parameter
            //but scheme itself has the param map!

            //this is something of an issue, as we no longer have the canonical expression tree at hand (was wasted in parsing)
            //seems that the building of the param map should be done at the beginning, as part of parsing...


            var scheme = new QueryScheme();

            

            return scheme;
        }


        static Scheme Schematize(Scheme prevScheme, FetchOp op) {
            throw new NotImplementedException();
        }

    }

       
        
}
