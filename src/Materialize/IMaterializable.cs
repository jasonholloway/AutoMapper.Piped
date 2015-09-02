using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Materialize
{

    public interface IMaterializable : IEnumerable
    {
        //...
    }


    public interface IMaterializable<TDest> : IMaterializable, IEnumerable<TDest>
    {
        //Nothing to add here - get enumerator is the important one
        

        //all such operations should really communicate individually throught the interface.
        //that is, in a perfect world, MaterializeAs() should return a new query, served by
        //a new query-provider, which parses its fed expression tree, and either passes through
        //commands to the server, or retains them to be run on the fetched and transformed enumeration.
        //Wouldn't be impossible, but would be a further step. Best to stick to the above, I think.




    }
}
