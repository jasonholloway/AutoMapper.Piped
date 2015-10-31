using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Materialize.Reify2.Parsing2.Methods
{
    abstract class SequenceMethodHandler : ParseHandler
    {
        protected IEnumerable<ITransition> Upstream { get; private set; }

        protected abstract IEnumerable<ITransition> InnerRespond();


        protected MethodCallExpression Call {
            get { return Subject.CallExp; }
        }


        public override IEnumerable<ITransition> Respond() 
        {
            var upstreamSubject = Subject.Spawn(Subject.CallExp.Arguments[0]);

            Upstream = Parser.Parse(upstreamSubject).ToArray();

            return Upstream.Concat(InnerRespond());               
        }
        

    }
}
