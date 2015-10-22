using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Materialize.Reify2.Parsing.Methods.Quantifiers
{
    class QuantifierHandler : MethodHandlerBase
    {
        protected override IParseStrategy Strategize() 
        {            
            //UpstreamStrategy.FiltersFetchedSet 

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
