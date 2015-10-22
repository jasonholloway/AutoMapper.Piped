using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Materialize.Reify2.Parsing.Methods.Aggregators
{
    class CountHandler : MethodHandlerBase
    {
        protected override IParseStrategy Strategize() 
        {
            if(UpstreamStrategy.FiltersFetchedSet) {
                return CreateStrategy(
                            typeof(CountOnClientStrategy<,>).MakeGenericType(SourceType, ElemType),
                            UpstreamStrategy);
            }
            else {
                return CreateStrategy(
                            typeof(CountOnServerStrategy<,>).MakeGenericType(SourceType, ElemType),
                            UpstreamStrategy);
            }            
        }
    }
}
