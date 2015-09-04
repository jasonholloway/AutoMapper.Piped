using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Materialize.Reification
{
    class Reifier<TSource, TDest> : IReifyNode
    {
        //behaviour should be built from typevectors, strategies, etc.        
        //MaterializeAs creates this, then feeds it to ReifyQueryProvider, which uses it as its base
        //as part of the hodge-podge that will be Materializable

        public Expression TransformExpression(Expression exp) {
            //projection
            throw new NotImplementedException();
        }

        public object TransformFetched(object inp) {
            //tranformation
            throw new NotImplementedException();
        }
        
    }
}
