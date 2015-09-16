using System;
using System.Collections.Generic;
using System.Linq;


namespace Materialize.Reify.Parsing.CallParsing
{
    abstract class CallParseRule
        : ICallParseRule
    {
        public abstract CallParserFactory GetParserFactory(CallParseContext ctx);
               
        protected CallParserFactory BuildParserFactory(
            Type type,
            params object[] ctorArgs) 
        {
            return (Parser p) => {
                var args = new[] { p }.Concat(ctorArgs).ToArray();
                return (ICallParser)Activator.CreateInstance(type, args);
            };
        }
        
    }

}
