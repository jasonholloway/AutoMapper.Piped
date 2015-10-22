using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;

namespace Materialize.Reify2.Mapping
{    

    abstract class MapperModifier<TSource, TFetch, TDest>
        : IModifier
    {

        protected virtual Expression ServerFilter(Expression exQuery) {
            return exQuery;
        }

        protected virtual Expression ServerProject(Expression exQuery) {
            return exQuery;
        }

        protected virtual Expression ClientTransform(Expression exTransform) {
            return exTransform;
        }



        Expression IModifier.ServerFilter(Expression exQuery) {
            Debug.Assert(typeof(TSource).IsAssignableFrom(exQuery.Type));

            return ServerFilter(exQuery);
        }


        Expression IModifier.ServerProject(Expression exQuery) {
            var exRewritten =  ServerProject(exQuery);

            Debug.Assert(typeof(TFetch).IsAssignableFrom(exRewritten.Type));

            return exRewritten;
        }


        Expression IModifier.ClientTransform(Expression exTransform) {
            Debug.Assert(typeof(TFetch).IsAssignableFrom(exTransform.Type));

            var exRewritten = ClientTransform(exTransform);

            Debug.Assert(typeof(TDest).IsAssignableFrom(exRewritten.Type));

            return exRewritten;
        }









        //[Obsolete]
        //protected abstract Expression FetchMod(Expression exSource);

        //[Obsolete]
        //protected abstract Expression TransformMod(Expression exFetched);

                
        //Expression IModifier.FetchMod(Expression exFetch) {
        //    Debug.Assert(typeof(TSource).IsAssignableFrom(exFetch.Type));

        //    var exModded = FetchMod(exFetch);

        //    Debug.Assert(typeof(TFetch).IsAssignableFrom(exModded.Type));

        //    return exModded;
        //}


        //Expression IModifier.TransformMod(Expression exTransform) {
        //    Debug.Assert(typeof(TFetch).IsAssignableFrom(exTransform.Type));

        //    var exModded = TransformMod(exTransform);

        //    Debug.Assert(typeof(TDest).IsAssignableFrom(exModded.Type));

        //    return exModded;
        //}


        //[Obsolete]
        //protected abstract TDest Transform(TFetch fetched);

        //[Obsolete]
        //object IModifier.Transform(object fetched) {
        //    return Transform((TFetch)fetched);
        //}
        

    }


}
