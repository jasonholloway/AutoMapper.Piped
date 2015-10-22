using Materialize.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace Materialize.Reify2.Parsing.Methods.Partitioners
{
    //Simple Skip and Take...

    class PartitionerHandler : MethodHandlerBase
    {

        protected override IParseStrategy Strategize() 
        {            
            if(UpstreamStrategy.FiltersFetchedSet) {
                //client-side
                throw new NotImplementedException();
            }
            else {
                return CreateStrategy(
                            typeof(PartitionerOnServerStrategy<,,>).MakeGenericType(SourceType, SourceType.GetEnumerableElementType(), ElemType),
                            UpstreamStrategy,
                            MethodDef);
            }
        }

    }
}
