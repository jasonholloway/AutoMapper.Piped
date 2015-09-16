using System;
using System.Collections.Generic;
using System.Linq;

namespace Materialize.Reify.Parsing.CallParsing
{
    abstract class CallParseRule
        : ICallParseRule
    {
        public abstract ICallParseStrategy GetStrategy(CallParseContext ctx);
               
        protected ICallParseStrategy CreateStrategy(
            Type type,
            params object[] ctorArgs) 
        {
            return (ICallParseStrategy)Activator.CreateInstance(type, ctorArgs);
        }        
    }

}
