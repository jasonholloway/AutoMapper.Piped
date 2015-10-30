using System;
using System.Collections.Generic;
using System.Linq;

namespace Materialize.Reify2.Parsing2.Methods
{
    abstract class SequenceMethodHandler : ParseHandler
    {
        protected IEnumerable<ITransition> Upstream { get; private set; }

        protected abstract IEnumerable<ITransition> InnerRespond();


        public override IEnumerable<ITransition> Respond() 
        {
            var upstreamSubject = Subject.Spawn(Subject.CallExp.Arguments[0]);

            Upstream = Parser.Parse(upstreamSubject).ToArray();

            return Upstream.Concat(InnerRespond());               
        }
        

    }
}
