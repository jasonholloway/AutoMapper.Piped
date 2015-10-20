using System;
using System.Linq.Expressions;

namespace Materialize.Reify
{
    interface IModifier
    {
        Expression ServerFilter(Expression exQuery);
        Expression ServerProject(Expression exQuery);                
        Expression ClientTransform(Expression exTransform);






        //[Obsolete]
        //Expression FetchMod(Expression exFetch);
        
        //[Obsolete]
        //Expression TransformMod(Expression exTransform);
        
        //[Obsolete]
        //object Transform(object fetched);
    }
}
