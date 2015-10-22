using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Materialize.SourceRegimes
{
    //back-up option - accepts only most basic operations
    //basically tells client to do everything

    class TolerantRegimeProvider : ISourceRegimeProvider
    {
        public ISourceRegime GetRegime(IQueryable qySource) {
            return new TolerantRegime();
        }
    }


    class TolerantRegime : ISourceRegime
    {
        public bool ServerAccepts(Expression exp) {
            return true;
        }
    }
}
