using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Materialize.Reify.Parsing
{   
    //*****************************************************
    //FASCINATING: TUpstreamOut should always == TSource! *
    //*****************************************************

    abstract class ParseModifier<TUpstreamOut, TDest> 
        : IModifier
    {
        IModifier _upstreamMod;
                
        public ParseModifier(IModifier upstreamMod) {
            _upstreamMod = upstreamMod;
        }


        protected abstract Expression Rewrite(Expression exQuery);

        protected Expression UpstreamRewrite(Expression exQuery) {
            return _upstreamMod.Rewrite(exQuery);
        }

        Expression IModifier.Rewrite(Expression exQuery) {
            return Rewrite(exQuery);
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
