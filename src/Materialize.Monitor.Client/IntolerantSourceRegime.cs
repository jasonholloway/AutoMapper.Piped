using Materialize.SourceRegimes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Materialize.Monitor.Client
{
    public class IntolerantSourceRegime : ISourceRegime
    {
        public bool ServerAccepts(Expression exp) {
            return false;
        }
    }
}
