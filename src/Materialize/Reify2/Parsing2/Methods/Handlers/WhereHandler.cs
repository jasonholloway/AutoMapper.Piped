using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Materialize.Reify2.Parsing2.Methods.Handlers
{
    class WhereHandler : SequenceMethodHandler
    {
        protected override IEnumerable<IElement> InnerRespond() 
        {





            yield return ElementFactory();
        }
    }
}
