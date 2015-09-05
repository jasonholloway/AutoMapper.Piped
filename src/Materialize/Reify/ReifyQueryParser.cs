using Materialize.Reify.Mods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Materialize.Reify
{
    class ReifyQueryParser
    {
        //minimally featured at mo: will only handle unary queryable methods and base constant.

        Reifiable _baseReifiable;
        Func<IModifier> _fnBaseModifier;

        public ReifyQueryParser(Reifiable baseReifiable, Func<IModifier> fnBaseModifier) {
            _baseReifiable = baseReifiable;
            _fnBaseModifier = fnBaseModifier;
        }


        public IModifier Parse(Expression ex) {
            switch(ex.NodeType) {
                case ExpressionType.Call:
                    return ParseCall((MethodCallExpression)ex);

                case ExpressionType.Constant:
                    return ParseConstant((ConstantExpression)ex);

                default:
                    throw new InvalidOperationException("ReifyQueryParser doesn't like its input!");
            }
        }


        

        ISet<MethodInfo> _unaryMethodDefs = new HashSet<MethodInfo>(new MethodInfo[] {
            ReflectionHelper.GetGenericMethodDef(() => Queryable.First<int>(null)),
            ReflectionHelper.GetGenericMethodDef(() => Queryable.Last<int>(null)),
            ReflectionHelper.GetGenericMethodDef(() => Queryable.Single<int>(null)),
            ReflectionHelper.GetGenericMethodDef(() => Queryable.FirstOrDefault<int>(null)),
            ReflectionHelper.GetGenericMethodDef(() => Queryable.LastOrDefault<int>(null)),
            ReflectionHelper.GetGenericMethodDef(() => Queryable.SingleOrDefault<int>(null))
        });



        IModifier ParseCall(MethodCallExpression ex) 
        {
            if(ex.Method.DeclaringType == typeof(Queryable))
            {
                var genMethod = ex.Method.GetGenericMethodDefinition();
                
                if(_unaryMethodDefs.Contains(genMethod)) 
                {                   
                    var upstreamMod = Parse(ex.Arguments.First());

                    return new Modifier(
                                    upstreamMod,
                                    e => Expression.Call(e, ex.Method)
                                    );
                }
            }
            
            throw new InvalidOperationException();            
        }



        IModifier ParseConstant(ConstantExpression ex) 
        {
            if(ex.Value == _baseReifiable) {
                return _fnBaseModifier();
            }

            throw new InvalidOperationException();
        }



    }
}
