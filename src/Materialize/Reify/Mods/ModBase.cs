using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Materialize.Reify.Mods
{
    abstract class ModBase : IModifier
    {
        public abstract Expression RewriteQuery(Expression exQuery);
        public abstract object TransformFetched(object fetched);
    }
}
