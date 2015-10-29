using Materialize.Reify2.Params;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Materialize.Reify2.Compiling
{


    internal abstract class Scheme
    {
        public Type OutType { get; protected set; }
        public ParameterMap Params { get; protected set; }

        public abstract Func<ArgumentMap, object> Compile();
    }



    class QueryScheme : Scheme
    {
        public override Func<ArgumentMap, object> Compile() {
            throw new NotImplementedException();
        }
    }



}
