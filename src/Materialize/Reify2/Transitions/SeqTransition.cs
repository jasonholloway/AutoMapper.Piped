using Materialize.SequenceMethods;
using System.Linq.Expressions;
using System.Collections.Generic;
using Materialize.Types;
using System.Reflection;
using System;
using System.Linq;

namespace Materialize.Reify2.Transitions
{   
       
    internal abstract partial class SeqTransition : Transition
    {
        protected Mode[] _modes;

        public abstract SeqMethod SeqMethod { get; }
        public abstract IEnumerable<Expression> Args { get; }
        

        public void SetTypeArg(int position, Type type) {
            foreach(var mode in _modes) {
                mode.TypeArgHub.Register(
                                new TypeArg(
                                        mode.TypeArgHub.TypeParams.ElementAt(position),
                                        type),
                                null);
            }
        }




        public MethodCallExpression GetCallExpression() 
        {
            var mode = _modes.FirstOrDefault(m => m.Status == ModeStatus.Matched)
                            ?? _modes.FirstOrDefault(m => m.Status == ModeStatus.Forced);

            if(mode == null) {
                throw new InvalidOperationException("No acceptible mode found!");
            }

            return mode.GetCallExpression();
        }
        
        
    }        
       

}
