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

        delegate IModifier Handler(ReifyQueryParser p, MethodCallExpression ex);

        static Dictionary<MethodInfo, Handler> _dHandlers = new Dictionary<MethodInfo, Handler>();

        static void RegisterHandlerForMethod(MethodInfo method, Handler fnHandler) {
            _dHandlers[method] = fnHandler;
        }


        static ReifyQueryParser() {
            var mFirst = Refl.GetGenericMethodDef(() => Queryable.First<int>(null));

            RegisterHandlerForMethod(mFirst,
                (p, ex) => {
                    return new UnaryModifier(
                                    p.Parse(ex.Arguments[0]),
                                    mFirst);
                });


            var mFirstOrDef = Refl.GetGenericMethodDef(() => Queryable.FirstOrDefault<int>(null));

            RegisterHandlerForMethod(mFirstOrDef,
                (p, ex) => {
                    return new UnaryModifier(
                                    p.Parse(ex.Arguments[0]),
                                    mFirstOrDef);
                });





            var mLast = Refl.GetGenericMethodDef(() => Queryable.Last<int>(null));

            RegisterHandlerForMethod(mLast,
                (p, ex) => {
                    return new UnaryModifier(
                                    p.Parse(ex.Arguments[0]),
                                    mLast);
                });


            var mLastOrDef = Refl.GetGenericMethodDef(() => Queryable.LastOrDefault<int>(null));

            RegisterHandlerForMethod(mLastOrDef,
                (p, ex) => {
                    return new UnaryModifier(
                                    p.Parse(ex.Arguments[0]),
                                    mLastOrDef);
                });



            var mSingle = Refl.GetGenericMethodDef(() => Queryable.Single<int>(null));

            RegisterHandlerForMethod(mSingle,
                (p, ex) => {
                    return new UnaryModifier(
                                    p.Parse(ex.Arguments[0]),
                                    mSingle);
                });


            var mSingleOrDef = Refl.GetGenericMethodDef(() => Queryable.SingleOrDefault<int>(null));

            RegisterHandlerForMethod(mSingleOrDef,
                (p, ex) => {
                    return new UnaryModifier(
                                    p.Parse(ex.Arguments[0]),
                                    mSingleOrDef);
                });






            var mTake = Refl.GetGenericMethodDef(() => Queryable.Take<int>(null, 1));

            RegisterHandlerForMethod(mTake,
                (p, ex) => {
                    return new AdLibModifier(
                                    p.Parse(ex.Arguments[0]),
                                    exSource => Expression.Call(
                                                            mTake.MakeGenericMethod(Refl.GetElementType(ex.Type)),
                                                            exSource,
                                                            ex.Arguments[1])
                                    );
                });


            var mSkip = Refl.GetGenericMethodDef(() => Queryable.Skip<int>(null, 1));

            RegisterHandlerForMethod(mSkip,
                (p, ex) => {
                    return new AdLibModifier(
                                    p.Parse(ex.Arguments[0]),
                                    exSource => Expression.Call(
                                                            mSkip.MakeGenericMethod(Refl.GetElementType(ex.Type)),
                                                            exSource,
                                                            ex.Arguments[1])
                                    );
                });
            
        }


        //----------------------------------------------------------------------------



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
            var method = ex.Method.IsGenericMethod
                            ? ex.Method.GetGenericMethodDefinition()
                            : ex.Method;
            
            try {
                var fnHandler = _dHandlers[method];
                return fnHandler(this, ex);
            }
            catch(KeyNotFoundException) {
                throw new InvalidOperationException("ReifyQueryParser has encountered an unhandled MethodCallExpression!");
            }            
        }
               

    }
}
