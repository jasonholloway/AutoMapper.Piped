using Materialize.Reify2.Transitions;
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
        protected override IEnumerable<ITransition> InnerRespond() 
        {
            var exPred = (LambdaExpression)((UnaryExpression)Subject.CallExp.Arguments[1]).Operand;

            yield return new FilterTransition(exPred);                          
        }        
    }
}
