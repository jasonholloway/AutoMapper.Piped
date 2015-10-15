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
        ParseStrategySource _parseStrategies;

        public ParserFactory(ParseStrategySource parseStrategies) {
            _parseStrategies = parseStrategies;
        }
        
        public Parser Create(Expression exBase, ReifyContext reifyContext) {
            return new Parser(exBase, reifyContext, _parseStrategies);
        }
    }
}
