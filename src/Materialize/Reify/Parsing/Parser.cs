using Materialize.Reify.Modifiers;
using Materialize.Reify.Parsing;
using Materialize.Reify.Parsing.CallParsing;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace Materialize.Reify.Parsing
{
    //parser delegates to strategies for CallExpression handling





    class Parser
    {
        Expression _baseExp;
        IModifier _baseModifier;
        ICallParseStrategySource _callParseStrategies;

        public Parser(
            Expression baseExp, 
            IModifier baseModifier,
            ICallParseStrategySource callParseStrategies) 
        {
            _baseExp = baseExp;
            _baseModifier = baseModifier;
            _callParseStrategies = callParseStrategies;
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
        
        
        IModifier ParseCall(MethodCallExpression exCall) 
        {
            //certain flags need to be tracked, based on characteristics of resolved strategies
            
            //how to pass these between strategies? Parser could accumulate info, though this seems naff.
            //Seems best way, however.

            var parseContext = new CallParseContext(exCall.Method);

            var callParseStrategy = _callParseStrategies.GetStrategy(parseContext);

            var callParser = callParseStrategy.CreateCallParser(this);
            
            var modifier = callParser(exCall);

            return modifier;
        }
               

    }
}
