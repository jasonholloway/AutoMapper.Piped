using System;
using System.Linq;
using System.Linq.Expressions;

namespace Materialize
{
    interface IReifier
    {
        Expression Map(Expression exSource);
        object Finalize(object orig);
    }

    interface IReifier<TOrig, TDest>
        : IReifier
    {
        //...
    }


    abstract class ReifierBase<TOrig, TDest>
        : IReifier<TOrig, TDest>
    {
        public Expression Map(Expression exSource) 
        {
            if(typeof(IQueryable).IsAssignableFrom(exSource.Type)) 
            {
                var exInParam = Expression.Parameter(typeof(TOrig));
                var exLambdaBody = MapSingle(exInParam);

                var tIn = typeof(TOrig);
                var tOut = exLambdaBody.Type;

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






        public object Finalize(object obj) {

            //need to pull similar trick as above: frame problem nicely for derivations

            throw new NotImplementedException();
        }

        protected abstract TDest FinalizeSingle(object obj);
    }


}
