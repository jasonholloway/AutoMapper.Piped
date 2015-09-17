using Materialize.Reify.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Materialize.Reify.Parsing
{
    class ParserFactory
    {
        IParseStrategySource _parseStrategies;

        public ParserFactory(IParseStrategySource parseStrategies) {
            _parseStrategies = parseStrategies;
        }
        
        public Parser Create(Expression exBase, MapContext mapContext) {
            return new Parser(exBase, mapContext, _parseStrategies);
        }
    }
}
