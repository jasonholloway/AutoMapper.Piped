using Materialize.Reify2.Parameterize;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using Materialize.Types;

namespace Materialize.Tests.Inner.Fakes
{
    class ParamMapFake : ParamMap
    {
        public ParamMapFake()
            : base(Enumerable.Empty<Param>()) { }

        public override NodeAccessor TryGetAccessor(Expression ex) {            
            return x => Expression.Constant(DefaultValueFactory.GetForType(x.Type));
        }        
    }
}
