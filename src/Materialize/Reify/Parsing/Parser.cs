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
        ICallParserProvider _callParsers;

        public Parser(
            Expression baseExp, 
            IModifier baseModifier,
            ICallParserProvider callParsers) 
        {
            _baseExp = baseExp;
            _baseModifier = baseModifier;
            _callParsers = callParsers;
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
            
            var parseContext = new CallParseContext(exCall.Method);

            var callParser = _callParsers.GetParser(this, parseContext);
            
            var modifier = callParser.Parse(exCall);

            return modifier;
        }
               

    }
}
