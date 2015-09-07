﻿using Materialize.Reify.Modifiers;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;

namespace Materialize.Reify.Mapping
{
    abstract class MapperModifier<TOrig, TDest>
        : MapperModifier<TOrig, TDest, TDest>
    { }


    abstract class MapperModifier<TOrig, TMed, TDest>
        : IModifier
    {

        public Expression RewriteQuery(Expression exSource) 
        {
            if(typeof(IQueryable).IsAssignableFrom(exSource.Type)) 
            {
                var exInParam = Expression.Parameter(typeof(TOrig));
                var exLambdaBody = RewriteSingle(exInParam);

                Debug.Assert(exLambdaBody.Type == typeof(TMed));

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
                return RewriteSingle(exSource);
            }
        }

        protected abstract Expression RewriteSingle(Expression exSource);
        
        

        public object TransformFetched(object obj) 
        {
            if(typeof(IEnumerable<TMed>).IsAssignableFrom(obj.GetType())) 
            {
                return ((IEnumerable<TMed>)obj)
                            .Select(e => TransformSingle(e));
            }
            else {
                return TransformSingle((TMed)obj);
            }            
        }

        protected abstract TDest TransformSingle(TMed obj);

    }


}
