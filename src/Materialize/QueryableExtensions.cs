using Materialize.Reify;
using System.Linq;

namespace Materialize
{
    public static class QueryableExtensions
    {        
        public static IMaterializable<TDest> MaterializeAs<TDest>(this IQueryable qyOrig) 
        {
            var queryable = (IQueryable<TDest>)Reifiable.Create(qyOrig, typeof(TDest));
            return new Materializable<TDest>(queryable);
        }
    }
}
