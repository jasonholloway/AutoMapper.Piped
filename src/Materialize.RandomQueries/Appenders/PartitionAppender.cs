using Materialize.RandomQueries.Bits;
using Materialize.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace Materialize.RandomQueries.Appenders
{
    class PartitionAppender : Appender
    {
        MethodInfo _method = Rand.FromList(
                                    QueryableMethods.Take,
                                    QueryableMethods.Skip);

        int _count = Rand.FromRange(1, 50);


        public override Expression Append(Expression exInput) {
            return Expression.Call(
                                _method.MakeGenericMethod(Context.ElemType),
                                exInput,
                                Expression.Constant(_count)
                                );
        }

        public override AppendContext GetResultContext() {
            return Context;
        }
    }
}
