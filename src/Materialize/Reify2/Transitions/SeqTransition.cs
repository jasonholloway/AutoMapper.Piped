using Materialize.SequenceMethods;
using System.Linq.Expressions;
using System.Collections.Generic;
using Materialize.Types;

namespace Materialize.Reify2.Transitions
{
    internal abstract partial class SeqTransition : Transition
    {
        protected TypeArgHub _typeArgHub;


        public abstract SeqMethod SeqMethod { get; }

        public abstract IEnumerable<Expression> Args { get; }
        

        public IEnumerable<TypeArg> GetTypeArgs() {
            return _typeArgHub.GetTypeArgs();
        }
        
    }        
       

}
