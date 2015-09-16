using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Materialize.Reify.Parsing
{   

    abstract class ParserModifier<TTransIn, TTransOut> : IModifier
    {
        IModifier _upstreamMod;
                
        public ParserModifier(IModifier upstreamMod) {
            _upstreamMod = upstreamMod;
        }


        protected abstract Expression Rewrite(Expression exQuery);

        protected Expression UpstreamRewrite(Expression exQuery) {
            return _upstreamMod.Rewrite(exQuery);
        }

        Expression IModifier.Rewrite(Expression exQuery) {
            return Rewrite(exQuery);
        }


        protected abstract TTransOut Transform(object fetched);

        protected TTransIn UpstreamTransform(object fetched) {
            return (TTransIn)_upstreamMod.Transform(fetched);
        }

        object IModifier.Transform(object fetched) {
            return Transform(fetched);
        }

    }
}
