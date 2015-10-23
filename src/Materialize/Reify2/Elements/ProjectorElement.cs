using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Materialize.Reify2.Elements
{
    class ProjectorElement<TBefore, TAfter> : ElementBase
    {

        public Expression<Func<TBefore, TAfter>> Projection { get; private set; }
                

        public ProjectorElement(Expression<Func<TBefore, TAfter>> projection) 
            : base(ElementType.Projector) 
        {
            Projection = projection;
            OutType = typeof(IQueryable<TAfter>);
        }



        public IElement Rebase<TFilterElem>(FilterElement<TFilterElem> filter) 
        {            
            throw new NotImplementedException();
        }



    }
}
