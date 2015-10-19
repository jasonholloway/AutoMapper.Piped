using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;

namespace Materialize.Reify.Mapping
{    

    abstract class MapperModifier<TSource, TFetch, TDest>
        : IModifier
    {        
        protected abstract Expression FetchMod(Expression exSource);
        protected abstract Expression TransformMod(Expression exFetched);

                
        Expression IModifier.FetchMod(Expression exFetch) {
            Debug.Assert(typeof(TSource).IsAssignableFrom(exFetch.Type));

            var exModded = FetchMod(exFetch);

            Debug.Assert(typeof(TFetch).IsAssignableFrom(exModded.Type));

            return exModded;
        }


        Expression IModifier.TransformMod(Expression exTransform) {
            Debug.Assert(typeof(TFetch).IsAssignableFrom(exTransform.Type));

            var exModded = TransformMod(exTransform);

            Debug.Assert(typeof(TDest).IsAssignableFrom(exModded.Type));

            return exModded;
        }


        [Obsolete]
        protected abstract TDest Transform(TFetch fetched);

        [Obsolete]
        object IModifier.Transform(object fetched) {
            return Transform((TFetch)fetched);
        }
        

    }


}
