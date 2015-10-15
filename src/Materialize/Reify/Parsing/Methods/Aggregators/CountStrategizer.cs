using Materialize.Reify.Parsing.Methods.Filters;
using Materialize.Types;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Materialize.Reify.Parsing.Methods.Aggregators
{
    abstract class CountParser : FilterParserBase
    {

        protected override IParseStrategy Strategize() {
            if(UpstreamStrategy.FiltersFetchedSet) {
                throw new NotImplementedException();
            }
            else {
                throw new NotImplementedException();
            }
        }
        
    }
}
