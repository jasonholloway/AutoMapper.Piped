using Materialize.SequenceMethods;
using System.Linq.Expressions;
using System.Collections.Generic;
using Materialize.Types;
using System.Reflection;
using System;
using System.Linq;

namespace Materialize.Reify2.Transitions
{
    //can't force when requesting the method...
    //as forcing relates to types primarily. 

    //could try and force a transition to a mode...
    //so, if no mode possible, then we try to force a mode out of the transition

    //SO: we don't GetMethod from the transition, but try and get a SeqCall out of it...
    //or even better, a callexpression!
    
       
    internal abstract partial class SeqTransition : Transition
    {
        protected Mode[] _modes;

        public abstract SeqMethod SeqMethod { get; }
        public abstract IEnumerable<Expression> Args { get; }
        

        public MethodCallExpression GetCallExpression() 
        {
            var mode = _modes.FirstOrDefault(m => m.GetStatus() == ModeStatus.Matched)
                            ?? _modes.FirstOrDefault(m => m.GetStatus() == ModeStatus.Forced);

            if(mode == null) {
                throw new InvalidOperationException("No acceptible mode found!");
            }

            return mode.GetCallExpression();
        }
        
        
    }        
       

}
