using Materialize.Reify2.Elements;
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
        protected override IEnumerable<IElement> InnerRespond() 
        {
            var type = UpstreamElements.Last().OutType;
            var elemType = type.GetEnumerableElementType();

            yield return (IElement)Activator.CreateInstance(
                                            typeof(FilterElement<>).MakeGenericType(elemType),
                                            Expression.Lambda(
                                                    typeof(Func<,>).MakeGenericType(elemType, typeof(bool)),
                                                    Expression.Constant(true),
                                                    Expression.Parameter(elemType)
                                                    ));
        }
    }
}
