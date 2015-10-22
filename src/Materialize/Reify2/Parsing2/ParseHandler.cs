using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Materialize.Reify2.Parsing2
{    
    abstract class ParseHandler
    {
        protected ParseSubject Subject { get; private set; }

        protected Func<IElement> ElementFactory { get; private set; }

        
        public abstract IEnumerable<IElement> Respond();
        
        public static ParseHandler Create<THandler>(ParseSubject subject)
            where THandler : ParseHandler, new() 
        {
            var handler = new THandler();
            handler.Subject = subject;
            return handler;
        }

    }

}
