using Materialize.SourceRegimes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace Materialize.Demo2.Client
{
    public class IntolerantSourceRegime : ISourceRegime
    {
        public bool ServerAccepts(Expression exp) {
            return false;
        }
    }
}
