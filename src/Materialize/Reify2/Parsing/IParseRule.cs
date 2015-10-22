using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Materialize.Reify2.Parsing
{
    //The role of the rule: determine the correct strategy for the *shape* of the subject expression.
    //Don't be deciding based on constant values, as these vary across parses, yet the chosen strategy won't.
    
    interface IParseRule
    {
        IParseStrategy GetStrategy(ParseContext ctx);
    }
}
