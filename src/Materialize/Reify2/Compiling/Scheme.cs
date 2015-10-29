using Materialize.Reify2.Params;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Materialize.Reify2.Compiling
{



    internal class ArgMap
    {

    }


    internal abstract class Scheme
    {
        public Type OutType { get; protected set; }
        public ParamMap Params { get; protected set; }

        public abstract Func<ArgMap, object> Compile();
    }



    class QueryScheme : Scheme
    {
        public override Func<ArgMap, object> Compile() {
            throw new NotImplementedException();
        }
    }



}
