using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Materialize.Reify.Parsing
{   

    abstract class ParseModifier<TUpstreamOut, TDest> 
        : IModifier
    {
        IModifier _upstreamMod;
                
        public ParseModifier(IModifier upstreamMod) {
            _upstreamMod = upstreamMod;
        }


        protected abstract Expression FetchMod(Expression exQuery);

        protected Expression UpstreamFetchMod(Expression exQuery) {
            return _upstreamMod.FetchMod(exQuery);
        }

        Expression IModifier.FetchMod(Expression exQuery) {
            return FetchMod(exQuery);
        }




        protected abstract Expression TransformMod(Expression exQuery);

        protected Expression UpstreamTransformMod(Expression exQuery) {
            return _upstreamMod.TransformMod(exQuery);
        }

        Expression IModifier.TransformMod(Expression exQuery) {
            return TransformMod(exQuery);
        }










        protected abstract TDest Transform(object fetched);

        protected TUpstreamOut UpstreamTransform(object fetched) {
            return (TUpstreamOut)_upstreamMod.Transform(fetched);
        }

        object IModifier.Transform(object fetched) {
            return Transform(fetched);
        }

    }
}
