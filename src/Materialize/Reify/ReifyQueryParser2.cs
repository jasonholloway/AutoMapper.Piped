using Materialize.Reify.Modifiers;
using Materialize.Reify.Parsing;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace Materialize.Reify
{
    class ReifyQueryParser2
    {
        Expression _baseExp;
        IModifier _baseModifier;
        IParseStrategySource _strategySource;

        public ReifyQueryParser2(
            Expression baseExp, 
            IModifier baseModifier,
            IParseStrategySource strategySource) 
        {
            _baseExp = baseExp;
            _baseModifier = baseModifier;
            _strategySource = strategySource;
        }
                

        public IModifier Parse(Expression ex) 
        {
            if(ex == _baseExp) {
                return _baseModifier;
            }

            switch(ex.NodeType) {
                case ExpressionType.Call:
                    return ParseCall((MethodCallExpression)ex);
                    
                default:
                    throw new InvalidOperationException("ReifyQueryParser doesn't like its input!");
            }
        }
        
        
        IModifier ParseCall(MethodCallExpression ex) 
        {
            //certain flags need to be tracked, based on characteristics of resolved strategies

            var upstreamMod = Parse(ex.Arguments.First());


            var parseContext = new ParseContext(ex.Method);

            var strategy = _strategySource.GetStrategy(parseContext);
            
            var modifier = strategy.CreateModifier(upstreamMod);

            return modifier;
        }
               

    }
}
