using Materialize.Reifiables;
using System.Linq;

namespace Materialize
{
    public static class QueryableExtensions
    {        
        public static IMaterializable<TDest> MaterializeAs<TDest>(this IQueryable qyOrig) 
        {
            return Reifiable.Create<TDest>(qyOrig);      
        }

    }
}
