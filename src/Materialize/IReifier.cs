using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Materialize
{
    interface IReifier
    {
        Expression Map(Expression exSource);
        object Reform(object orig);
    }

    interface IReifier<TOrig, TDest>
        : IReifier
    {
        //...
    }





    abstract class ReifierBase<TOrig, TDest>
        : ReifierBase<TOrig, TDest, TDest>
    { }


    abstract class ReifierBase<TOrig, TMed, TDest>
        : IReifier<TOrig, TDest>
    {

        public Expression Map(Expression exSource) 
        {
            if(typeof(IQueryable).IsAssignableFrom(exSource.Type)) 
            {
                var exInParam = Expression.Parameter(typeof(TOrig));
                var exLambdaBody = MapSingle(exInParam);

                var tIn = typeof(TOrig);
                var tOut = exLambdaBody.Type;   //should be changed to use TMed, rather than expression type

                return Expression.Call(
                                typeof(Queryable),
                                "Select",
                                new[] { tIn, tOut },
                                exSource,
                                Expression.Lambda(
                                            typeof(Func<,>).MakeGenericType(tIn, tOut),
                                            exLambdaBody,
                                            exInParam)    
                                );
            }
            else {
                return MapSingle(exSource);
            }
        }

        protected abstract Expression MapSingle(Expression exSource);
        
        
        public object Reform(object obj) 
        {
            if(typeof(IEnumerable<TMed>).IsAssignableFrom(obj.GetType())) 
            {
                return ((IEnumerable<TMed>)obj)
                            .Select(e => ReformSingle(e));
            }
            else {
                return ReformSingle((TMed)obj);
            }            
        }

        protected abstract TDest ReformSingle(TMed obj);

    }


}
