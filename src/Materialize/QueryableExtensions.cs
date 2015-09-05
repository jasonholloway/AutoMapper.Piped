using Materialize.Reify;
using System.Linq;

namespace Materialize
{
    public static class QueryableExtensions
    {        
        public static IMaterializable<TDest> MaterializeAs<TDest>(this IQueryable qyOrig) 
        {
            return new Materializable<TDest>(
                            Reifiable.Create(qyOrig, typeof(TDest))
                            );
        }
    }
}
