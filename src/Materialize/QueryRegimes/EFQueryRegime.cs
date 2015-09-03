using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Materialize.QueryRegimes
{
    class EFQueryRegime : IQueryRegime
    {
        public bool MatchesProvider(IQueryProvider provider) {
            //test if EF provider somehow
            throw new NotImplementedException();
        }

        public bool Accepts(Expression exp) {
            //No non-EDM functions!

            //No non-model member accesses!

            //No ctors with parameters!

            //No projection to mapped model entities!
            
            throw new NotImplementedException();
        }
    }
}
