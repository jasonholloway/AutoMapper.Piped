using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Materialize.Reify.Parsing
{
    interface IParseRule
    {
        IParseStrategy DeduceStrategy(ParseContext ctx);
    }
}
