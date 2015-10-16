using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Materialize.RandomQueries.Appenders
{
    class WhereAppender : Appender
    {
        public override Expression Append(Expression exInput) {
            return exInput;
        }

        public override AppendContext GetResultContext() {
            return Context;
        }
    }
}
