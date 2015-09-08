using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Materialize.SourceRegimes
{
    class EF6Regime : ISourceRegime
    {
        //Can this be written without hard dependency on EF? Doubtful.
        //Really need access to context metadata for EDM testing.

        public bool MatchesProvider(IQueryProvider provider) {
            //test if EF provider somehow
            throw new NotImplementedException();
        }

        public bool ServerAccepts(Expression exp) {
            //No non-EDM functions!

            //No non-model member accesses!

            //No parameterised ctors!

            //No projection to mapped entities!
            
            throw new NotImplementedException();
        }
    }
}
