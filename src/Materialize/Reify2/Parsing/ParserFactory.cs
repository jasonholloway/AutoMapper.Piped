using Materialize.Reify2.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Materialize.Reify2.Parsing
{
    class ParserFactory
    {
        ParseStrategySource _parseStrategies;

        public ParserFactory(ParseStrategySource parseStrategies) {
            _parseStrategies = parseStrategies;
        }
        
        public Parser Create(Expression exBase, Type sourceType, ReifyContext reifyContext) {
            return new Parser(exBase, sourceType, reifyContext, _parseStrategies);
        }
    }
}
