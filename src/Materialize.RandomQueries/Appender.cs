using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Materialize.RandomQueries
{
    abstract class Appender
    {
        public AppendContext Context { get; set; }

        public abstract AppendContext GetResultContext();

        public abstract Expression Append(Expression exInput);
    }
}
