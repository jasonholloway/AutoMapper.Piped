using Materialize.RandomQueries.Appenders;
using Materialize.RandomQueries.Bits;
using Materialize.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Materialize.RandomQueries
{
    public class RandomQueryProvider
    {
        delegate Appender AppenderFac();
        
        AppenderFac[] _appenderFacs = {
            () => new WhereAppender(),
            () => new PartitionAppender()
        };

               

        public IQueryable GetRandomQuery(IQueryable qyBase) {
            var ex = GetRandomQueryExpression(qyBase.Expression);
            return qyBase.Provider.CreateQuery(ex);
        }


        Expression GetRandomQueryExpression(Expression exBase) 
        {
            var ctx = new AppendContext() {
                ElemType = exBase.Type.GetEnumerableElementType()
            };

            var ex = exBase;

            do {
                var app = GetRandomAppender(ctx);
                ex = app.Append(ex);
                ctx = app.GetResultContext();
            } while(Rand.FromProbability(0.5));

            return ex;
        }
                

        Appender GetRandomAppender(AppendContext ctx) {
            var appender = Rand.FromList(_appenderFacs)();
            appender.Context = ctx;
            return appender;
        }

               



    }
}
