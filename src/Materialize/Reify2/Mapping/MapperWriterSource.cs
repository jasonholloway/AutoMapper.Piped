using Materialize.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Materialize.Reify2.Mapping
{
    internal class MapperWriterSource
    {
        IMapStrategySource _strategySource;

        public MapperWriterSource(IMapStrategySource strategySource) {
            _strategySource = strategySource;
        }
        
        public IMapperWriter GetWriter(ReifyContext ctx, TypeVector types) {            
            var strategy = _strategySource.GetStrategy(new MapContext(types, ctx));
            return strategy.CreateWriter();
        }

    }
}
