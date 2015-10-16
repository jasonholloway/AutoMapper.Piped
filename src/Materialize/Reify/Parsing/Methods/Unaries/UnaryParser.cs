using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Materialize.Reify.Parsing.Methods.Unaries
{
    class UnaryParser : MethodParserBase
    {
        protected override IParseStrategy Parse() 
        {            
            if(UpstreamStrategy.FiltersFetchedSet) {
                return CreateStrategy(
                            typeof(UnaryOnClientStrategy<>).MakeGenericType(ElemType),
                            UpstreamStrategy,
                            MethodDef);
            }
            else {
                return CreateStrategy(
                            typeof(UnaryOnServerStrategy<>).MakeGenericType(ElemType),
                            UpstreamStrategy,
                            MethodDef);
            }
        }
    }
}
