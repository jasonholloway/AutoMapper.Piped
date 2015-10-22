using System;
using System.Collections.Generic;
using System.Linq;

namespace Materialize.Reify2.Parsing2.Methods
{
    abstract class SequenceMethodHandler : ParseHandler
    {
        protected IEnumerable<IElement> UpstreamElements { get; private set; }

        protected abstract IEnumerable<IElement> InnerRespond();


        public override IEnumerable<IElement> Respond() 
        {
            var upstreamSubject = Subject.Spawn(Subject.CallExp.Arguments[0]);

            UpstreamElements = Parser.Parse(upstreamSubject).ToArray();

            return UpstreamElements.Concat(InnerRespond());               
        }
        

    }
}
