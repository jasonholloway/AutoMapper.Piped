using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Materialize.Reify.Mods
{
    class MapperMod<TSource, TDest> : ModBase
    {
        //behaviour should be built from typevectors, strategies, etc.        
        //MaterializeAs creates this, then feeds it to ReifyQueryProvider, which uses it as its base
        //as part of the hodge-podge that will be Materializable

        public override Expression ModifySourceQuery(Expression exp) {
            //projection
            throw new NotImplementedException();
        }


        public override object ModifyReified(object inp) {
            //tranformation
            throw new NotImplementedException();
        }
        
    }
}
