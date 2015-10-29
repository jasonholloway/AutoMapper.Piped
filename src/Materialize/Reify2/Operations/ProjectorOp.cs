using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Materialize.Reify2.Operations
{

    abstract class ProjectorOp : OpBase
    {
        public ProjectorOp() 
            : base(OpType.Projector) { }

        public LambdaExpression Projection { get; protected set; }
        public Type InElemType { get; protected set; }
        public Type OutElemType { get; protected set; }
    }



    class ProjectorOp<TBefore, TAfter> : ProjectorOp
    {
        
        public ProjectorOp(Expression<Func<TBefore, TAfter>> projection) 
        {
            Projection = projection;
            OutType = typeof(IQueryable<TAfter>);
            InElemType = typeof(TBefore);
            OutElemType = typeof(TAfter);
        }



        public IOperation Rebase<TFilterElem>(FilterOp<TFilterElem> filter) 
        {            
            throw new NotImplementedException();
        }



    }
}
