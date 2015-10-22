using Materialize.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace Materialize.Reify2.Parsing.Methods.Partitioners
{
    //Skip and Take with predicates...

    class PredPartitionerHandler : MethodHandlerBase
    {        
        protected override IParseStrategy Strategize() 
        {            
            if(UpstreamStrategy.FiltersFetchedSet) {
                //client-side
                throw new NotImplementedException();
            }
            else {
                //server-side, inc. attempt at rebasing



                throw new NotImplementedException();
            }
        }

    }
}
