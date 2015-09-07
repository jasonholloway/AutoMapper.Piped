using Materialize.Reify.Modifiers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace Materialize.Reify
{
    class ReifyQueryParser
    {
        //minimally featured at mo: will only handle unary queryable methods and base constant.

        Expression _baseExp;
        IModifier _baseModifier;

        public ReifyQueryParser(
            Expression baseExp, 
            IModifier baseModifier) 
        {
            _baseExp = baseExp;
            _baseModifier = baseModifier;
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
            if(ex.Method.DeclaringType == typeof(Queryable))
            {
                var genMethod = ex.Method.GetGenericMethodDefinition();
                
                if(_unaryMethodDefs.Contains(genMethod)) 
                {                   
                    var upstreamMod = Parse(ex.Arguments.First());

                    return new UnaryModifier(
                                    upstreamMod, 
                                    ex.Method.GetGenericMethodDefinition());
                }
            }
            
            throw new InvalidOperationException();            
        }


        
        static ISet<MethodInfo> _unaryMethodDefs
            = new HashSet<MethodInfo>(new MethodInfo[] {
                                            ReflectionHelper.GetGenericMethodDef(() => Queryable.First<int>(null)),
                                            ReflectionHelper.GetGenericMethodDef(() => Queryable.Last<int>(null)),
                                            ReflectionHelper.GetGenericMethodDef(() => Queryable.Single<int>(null)),
                                            ReflectionHelper.GetGenericMethodDef(() => Queryable.FirstOrDefault<int>(null)),
                                            ReflectionHelper.GetGenericMethodDef(() => Queryable.LastOrDefault<int>(null)),
                                            ReflectionHelper.GetGenericMethodDef(() => Queryable.SingleOrDefault<int>(null))
                                        });
        

    }
}
