using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Materialize.Reify.Parsing.Methods
{
    interface IMethodStrategizer
    {
        ParseContext Context { set; }
        IParseStrategySource ParseStrategySource { set; }

        IParseStrategy Strategize();
    }
}
