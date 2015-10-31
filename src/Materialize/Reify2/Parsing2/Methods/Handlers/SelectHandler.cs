using Materialize.Reify2.Transitions;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Materialize.Reify2.Parsing2.Methods.Handlers
{
    class SelectHandler : SequenceMethodHandler
    {
        protected override IEnumerable<ITransition> InnerRespond() 
        {
            var exProj = (LambdaExpression)((UnaryExpression)Call.Arguments[1]).Operand;

            yield return new ProjectionTransition(exProj);
        }        
    }
}
