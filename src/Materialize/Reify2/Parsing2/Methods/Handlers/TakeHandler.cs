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
    class TakeHandler : SequenceMethodHandler
    {
        protected override IEnumerable<ITransition> InnerRespond() 
        {
            yield return new PartitionTransition(PartitionType.Take, Call.Arguments[1]);                          
        }        
    }
}
