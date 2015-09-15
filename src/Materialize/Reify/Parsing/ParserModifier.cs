﻿using System;
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
    

    abstract class ParserModifier<TIn, TOut> : IModifier
    {
        protected IModifier UpstreamMod { get; private set; }
        
        public ParserModifier(IModifier upstreamMod) {
            UpstreamMod = upstreamMod;
        }


        protected abstract Expression Rewrite(Expression exQuery);

        protected abstract TOut Transform(TIn fetched);


        Expression IModifier.Rewrite(Expression exQuery) {
            var ex = UpstreamMod.Rewrite(exQuery);
            return Rewrite(ex);
        }    
        
        object IModifier.Transform(object fetched) {
            var upstream = UpstreamMod.Transform(fetched);            
            return Transform((TIn)upstream);
        }        
    }
}
