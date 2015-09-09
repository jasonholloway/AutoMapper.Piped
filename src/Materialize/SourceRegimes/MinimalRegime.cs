using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Materialize.SourceRegimes
{
    class MinimalRegime : ISourceRegime
    {
        //back-up option - accepts only most basic operations
        //basically tells client to do everything

        public bool MatchesProvider(IQueryProvider provider) {
            return true;
        }

        public bool ServerAccepts(Expression exp) {
            return false;
        }
    }
}
