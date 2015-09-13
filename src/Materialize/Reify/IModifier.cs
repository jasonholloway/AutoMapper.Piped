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
        Expression Rewrite(Expression exQuery); 
        object Transform(object fetched);
    }
}
