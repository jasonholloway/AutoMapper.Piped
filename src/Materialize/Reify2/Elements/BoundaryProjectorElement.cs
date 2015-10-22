using Materialize.SourceRegimes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Materialize.Reify2.Elements
{
    class BoundaryProjectorElement<TBefore, TAfter> 
        : ProjectorElement<TBefore, TAfter>
    {
        public BoundaryProjectorElement(Expression<Func<TBefore, TAfter>> projection, ISourceRegime outRegime)
            : base(projection) 
        {
            ElementType |= ElementType.RegimeBoundary;
            OutRegime = outRegime;;
        }




        //again, these are transitions, really, not elements, which construe bodied spaces

        //and, as such, we can't just say one 'element' has one regime, or one type. 
        //each one is janus faced: there is a value before and a value after.

        //each one should have an OutType, and an OutRegime
        //InType and InRegime should be taken from the previous element 




               




    }
}
