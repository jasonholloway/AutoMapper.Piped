using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Materialize.QueryRegimes
{
    class MinimalQueryRegime : IQueryRegime
    {
        //back-up option - accepts only most basic operations
        //basically tells client to do everything

        public bool MatchesProvider(IQueryProvider provider) {
            return true;
        }

        public bool Accepts(Expression exp) {
            return false; //maybe should be more tolerant than this...
        }
    }
}
