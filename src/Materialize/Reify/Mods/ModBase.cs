using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Materialize.Reify.Mods
{
    abstract class ModBase : IMod
    {
        public abstract Expression ModifySourceQuery(Expression exQuery);
        public abstract object ModifyReified(object reified);
    }
}
