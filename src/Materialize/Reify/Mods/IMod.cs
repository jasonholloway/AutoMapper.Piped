using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Materialize.Reify.Mods
{
    interface IMod
    {
        Expression ModifySourceQuery(Expression exQuery); 
        object ModifyReified(object reified);
    }
}
