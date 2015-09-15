using System;
using System.Collections.Generic;
using System.Linq;


namespace Materialize.Reify.Parsing
{
    abstract class ParseRuleBase
        : IParseRule
    {
        public abstract IParseStrategy DeduceStrategy(ParseContext ctx);
               
        protected IParseStrategy CreateStrategy(
            Type type,
            params object[] ctorArgs) 
        {
            return (IParseStrategy)Activator.CreateInstance(type, ctorArgs);
        }
        
    }

}
