using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Materialize.Reify.Parsing.Methods.Unaries
{
    class SimpleUnaryStrategizer : MethodStrategizer
    {
        protected override IParseStrategy Strategize() 
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
