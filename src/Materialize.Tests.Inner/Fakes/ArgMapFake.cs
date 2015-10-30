using Materialize.Reify2.Params;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using Materialize.Types;

namespace Materialize.Tests.Inner.Fakes
{
    class ArgMapFake : ArgMap
    {
        IQueryable _qySource;

        public ArgMapFake(IQueryable qySource) {
            _qySource = qySource;
        }

        public override Expression GetIncidentalFor(Expression exCanonical) 
        {
            if(exCanonical.Type.IsQueryable()) {
                return _qySource.Expression;
            }

            return Expression.Constant(DefaultValueFactory.GetForType(exCanonical.Type));
        }
        
    }
}
