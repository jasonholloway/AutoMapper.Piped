﻿using Materialize.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace Materialize.Reify.Parsing.Methods.Partitioners
{
    //Simple Skip and Take...

    class SimplePartitionerStrategizer : MethodStrategizer
    {

        protected override IParseStrategy Strategize() 
        {            
            if(UpstreamStrategy.FiltersFetchedSet) {
                //client-side
                throw new NotImplementedException();
            }
            else {
                return CreateStrategy(
                            typeof(ServerSidePartitionerStrategy<>).MakeGenericType(ElemType),
                            UpstreamStrategy,
                            MethodDef);
            }
        }

    }
}
