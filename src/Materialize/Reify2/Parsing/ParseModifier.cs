using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Materialize.Reify2.Parsing
{   

    abstract class ParseModifier<TUpstreamOut, TDest> 
        : IModifier
    {
        IModifier _upstreamMod;
                
        public ParseModifier(IModifier upstreamMod) {
            _upstreamMod = upstreamMod;
        }
        
                
        protected virtual Expression ServerFilter(Expression exQuery) {
            return UpstreamServerFilter(exQuery);
        }

        protected virtual Expression ServerProject(Expression exQuery) {
            return UpstreamServerProject(exQuery);
        }
        
        protected virtual Expression ClientTransform(Expression exTransform) {
            return UpstreamClientTransform(exTransform);
        }




        //below should assert expression types in and out...
        //but this information is mostly with strategy, rather than modifier...


        Expression IModifier.ServerFilter(Expression exQuery) {            
            return ServerFilter(exQuery);
        }

        protected Expression UpstreamServerFilter(Expression exQuery) {
            return _upstreamMod.ServerFilter(exQuery);
        }
        



        Expression IModifier.ServerProject(Expression exQuery) {
            return ServerProject(exQuery);
        }

        protected Expression UpstreamServerProject(Expression exQuery) {
            return _upstreamMod.ServerProject(exQuery);
        }





        Expression IModifier.ClientTransform(Expression exTransform) 
        {
            var exRewritten = ClientTransform(exTransform);

            Debug.Assert(typeof(TDest).IsAssignableFrom(exRewritten.Type));

            return exRewritten;
        }

        protected Expression UpstreamClientTransform(Expression exTransform) 
        {
            var exUpstreamRewritten = _upstreamMod.ClientTransform(exTransform);

            Debug.Assert(typeof(TUpstreamOut).IsAssignableFrom(exUpstreamRewritten.Type));

            return exUpstreamRewritten;
        }










        //[Obsolete]
        //protected abstract Expression FetchMod(Expression exQuery);

        //[Obsolete]
        //protected Expression UpstreamFetchMod(Expression exQuery) {
        //    return _upstreamMod.FetchMod(exQuery);
        //}

        //Expression IModifier.FetchMod(Expression exQuery) {
        //    return FetchMod(exQuery);
        //}



        //[Obsolete]
        //protected abstract Expression TransformMod(Expression exQuery);

        //[Obsolete]
        //protected Expression UpstreamTransformMod(Expression exQuery) {
        //    return _upstreamMod.TransformMod(exQuery);
        //}

        //Expression IModifier.TransformMod(Expression exQuery) {
        //    return TransformMod(exQuery);
        //}




        


        //[Obsolete]
        //protected abstract TDest Transform(object fetched);

        //[Obsolete]
        //protected TUpstreamOut UpstreamTransform(object fetched) {
        //    return (TUpstreamOut)_upstreamMod.Transform(fetched);
        //}

        //object IModifier.Transform(object fetched) {
        //    return Transform(fetched);
        //}

    }
}
