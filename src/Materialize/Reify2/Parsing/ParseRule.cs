using System;
using System.Collections.Generic;
using System.Linq;

namespace Materialize.Reify2.Parsing
{
    abstract class ParseRule
        : IParseRule
    {
        public abstract IParseStrategy GetStrategy(ParseContext ctx);
               
        protected IParseStrategy CreateStrategy(
            Type type,
            params object[] ctorArgs) 
        {
            return (IParseStrategy)Activator.CreateInstance(type, ctorArgs);
        }        
    }

}
