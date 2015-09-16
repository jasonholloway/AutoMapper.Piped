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

        bool _filterOnClient;

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
            _filterOnClient |= callParseStrategy.FiltersFetchedSet; //should affect downstream, but perhaps it here affects upstream??? YES!!!!!!!!
            //BEWARE!!!!!!!

            //Need to delegate strategy-creation inward... before parser creation...
            //So that downstream strategies can be chosen against the characteristics of their upstream brethren.
            //Has to be part of STRATEGY-CHOOSING and so delegation must be done by rules, or by the parser that drives it all.
            //Yet the parser has no knowledge of how to get the instance argument from expressions.
            //Rules, however, do. Each rule must delegate upwards, and only finalise its strategy decision after upstream decisions have been spawned and closed.
            
            //Yet rules have no access to the expression, as they concern themselves only with the distilled CallParseContext. 
            //The parser has the exp, maybe it can be given knowledge of how to ascend tree of nodes? But rules and strategies are the proper places for
            //this. 
        
            //Would be simpler if strategies were summoned to cope with a particular expression tree: then each rule/strategy would have full access,
            //and would be able to freely behave as they should.

            //But this oppresses the cache, makes it miserable. Can hardly key on an entire expression tree. Well, we can, but then there are problems
            //relating to changing constants, etc. Constants could be transmogrified into anonymous parameters, and thereafter fully-formed hierarchies of strategies
            //could be cached. If cacheing is thus put to one side, with big ambitions of solving the problem keenly at a later date (and please DO: it's interesting)
            //Then the parsing operation becomes simplified. (and anyway, expression trees are usually going to be quite short and stubby: cheaper comparisons etc)
            
            //AGREED! Brittle strategy hierarchies it is. Fuck the cache, for the time being.
             
            



                        
            var callParser = callParseStrategy.CreateCallParser(this);
            
            var modifier = callParser(exCall);

            return modifier;
        }
               

    }
}
