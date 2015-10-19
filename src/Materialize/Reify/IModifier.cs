using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Materialize.Reify
{
    interface IModifier
    {
        Expression FetchMod(Expression exFetch);
        Expression TransformMod(Expression exTransform);


        [Obsolete]
        object Transform(object fetched);
    }
}
