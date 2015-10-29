using System;
using System.Collections.Generic;
using System.Linq;

namespace Materialize.Reify2.Parsing2.Methods
{
    abstract class SequenceMethodHandler : ParseHandler
    {
        protected IEnumerable<IOperation> UpstreamSteps { get; private set; }

        protected abstract IEnumerable<IOperation> InnerRespond();


        public override IEnumerable<IOperation> Respond() 
        {
            var upstreamSubject = Subject.Spawn(Subject.CallExp.Arguments[0]);

            UpstreamSteps = Parser.Parse(upstreamSubject).ToArray();

            return UpstreamSteps.Concat(InnerRespond());               
        }
        

    }
}
