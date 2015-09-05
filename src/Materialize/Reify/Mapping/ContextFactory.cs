using Materialize.Projection;
using Materialize.Reify.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Materialize.Reify.Mapping
{
    class ContextFactory
    {
        public static readonly ContextFactory Default = new ContextFactory();

        StrategyProvider _strategySource = StrategyProvider.Default;
        ProjectedTypeBuilder _projTypeBuilder = new ProjectedTypeBuilder();
        
        public Context CreateContext(Type tOrig, Type tDest) {
            return new Context(
                            null,
                            new TypeVector(tOrig, tDest),
                            _strategySource, 
                            null, 
                            _projTypeBuilder);
        }
    }
}
