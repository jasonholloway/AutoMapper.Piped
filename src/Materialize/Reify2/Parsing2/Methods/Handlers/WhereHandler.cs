using Materialize.Reify2.Operations;
using Materialize.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Materialize.Reify2.Parsing2.Methods.Handlers
{
    class WhereHandler : SequenceMethodHandler
    {
        protected override IEnumerable<IOperation> InnerRespond() 
        {
            var type = UpstreamSteps.Last().OutType;
            var elemType = type.GetEnumerableElementType();

            yield return (IOperation)Activator.CreateInstance(
                                            typeof(FilterOp<>).MakeGenericType(elemType),
                                            Expression.Lambda(
                                                    typeof(Func<,>).MakeGenericType(elemType, typeof(bool)),
                                                    Expression.Constant(true),
                                                    Expression.Parameter(elemType)
                                                    ));
        }
    }
}
