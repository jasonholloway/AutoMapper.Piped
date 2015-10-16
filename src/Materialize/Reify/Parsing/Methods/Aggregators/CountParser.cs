using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Materialize.Reify.Parsing.Methods.Aggregators
{
    class CountParser : MethodParserBase
    {
        protected override IParseStrategy Parse() 
        {
            if(UpstreamStrategy.FiltersFetchedSet) {
                return CreateStrategy(
                            typeof(CountOnClientStrategy<>).MakeGenericType(ElemType),
                            UpstreamStrategy);
            }
            else {
                return CreateStrategy(
                            typeof(CountOnServerStrategy<>).MakeGenericType(ElemType),
                            UpstreamStrategy);
            }            
        }
    }
}
