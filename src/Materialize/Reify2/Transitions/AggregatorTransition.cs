using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Materialize.Reify2.Transitions
{
    class AggregatorTransition : TransitionBase
    {
        //lumping different operations together isn't nice. Replication all over the shop.

        //the idea could be generalised: each separate case has an attendant bag of qualities.
        //

        //Each SeqMethod is an operation, to be tokenized. 
        

        public AggregatorTransition() 
            : base(TransitionType.Aggregator) {
        }
        
    }
}
