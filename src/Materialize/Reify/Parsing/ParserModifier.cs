using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Materialize.Reify.Parsing
{
    //Each ParserModifier has responsibilty for reading its incoming expression, taking the top off, and passing on...
    //to the next deduced strategy for the next part.

    //If not (though this would give it full collected information), then what? 
    //ParserVisitor would for each top expression, if it were a call... 




    //It's true: unlike mappers, each call node has no idea of what feeds it: it knows its type perhaps,
    //though this is largely useless by its self. And so it makes little sense for each modiifer to delegate
    //downwards for its source. Modifiers - or rather strategies - could however preempt their other typed 
    //arguments, if these are also to be parsed (far off in the future this). 

    //So contextual flagss are the only way for layers to communicate to each other.
    //But for this, they must be in charge of creating the child context... Or strategies
    //could just expose properties that could be fed back into subsequent contexts by the parser.
    

    abstract class ParserModifier<TUpstream, TDownstream> : IModifier
    {
        protected IModifier UpstreamMod { get; private set; }
        
        public ParserModifier(IModifier upstreamMod) {
            UpstreamMod = upstreamMod;
        }


        protected abstract Expression Rewrite(Expression exQuery);

        protected abstract TDownstream Transform(object fetched);


        protected Expression UpstreamRewrite(Expression exQuery) {
            return UpstreamMod.Rewrite(exQuery);
        }

        protected TUpstream UpstreamTransform(object fetched) {
            return (TUpstream)UpstreamMod.Transform(fetched);
        }



        //transform has two stages really: in and return. Inbetween is the delegation upstream.
        //Both stages have their unique typings, which should be enforced. Are these always knowable by the strategy/rule?

        //types:
        //  > In from above, to transform
        //  > Sent on downwards
        //  > Received upwards
        //  > Returned upwards      : That's four separate types! I suppose we must always know what these types are to be, as we have to work with them...
        //
        //


        Expression IModifier.Rewrite(Expression exQuery) {
            return Rewrite(exQuery);
        }    
        
        object IModifier.Transform(object fetched) {
            return Transform(fetched);            
        }        
    }
}
