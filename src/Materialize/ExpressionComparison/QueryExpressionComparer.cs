using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Materialize.ExpressionComparison
{
    class QueryExpressionComparer : ExpressionComparer
    {
        public QueryExpressionComparer() {
            CompareConstants = ConstantComparison.ByTypeOnly;
            CompareLambdaNames = NameComparison.None;
            CompareParameterNames = NameComparison.None;
        }
    }
}
