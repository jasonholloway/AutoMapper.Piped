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
        //...
    }
}
