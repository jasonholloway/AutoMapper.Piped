using Materialize.Reify;
using System.Linq;
using System.Linq.Expressions;

namespace Materialize
{
    public static class QueryableExtensions
    {        
        public static IMaterializable<TDest> MaterializeAs<TDest>(this IQueryable qyOrig) 
        {
            var reifiable = Reifiable.Create<TDest>(qyOrig);
                        
            return new Materializable<TDest>(reifiable.ReifyQuery);                                       
        }
    }
}
