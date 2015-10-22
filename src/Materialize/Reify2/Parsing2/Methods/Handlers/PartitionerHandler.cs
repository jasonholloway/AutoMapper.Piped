using System;
using System.Collections.Generic;
using System.Linq;

namespace Materialize.Reify2.Parsing2.Methods.Handlers
{
    class PartitionerHandler : SequenceMethodHandler
    {
        protected override IEnumerable<IElement> InnerRespond() {

            yield return ElementFactory();
        }
    }
}
