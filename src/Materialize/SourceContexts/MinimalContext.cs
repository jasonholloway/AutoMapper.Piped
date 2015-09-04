using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Materialize.SourceContexts
{
    class MinimalContext : ISourceContext
    {
        //back-up option - accepts only most basic operations
        //basically tells client to do everything

        public bool MatchesProvider(IQueryProvider provider) {
            return true;
        }

        public bool Accepts(Expression exp) {
            return false; //maybe should be more tolerant than this...

            //this would forbid property mapper bindings...
            //and also dest type ctors!
            
        }
    }
}
