using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Materialize.Reify.Parsing.Methods.Quantifiers
{
    class QuantifierParser : MethodParserBase
    {
        protected override IParseStrategy Parse() 
        {            
            if(UpstreamStrategy.FiltersFetchedSet) {
                //client side
                throw new NotImplementedException();
            }
            else {
                //server side
                throw new NotImplementedException();
            }
        }
    }
}
