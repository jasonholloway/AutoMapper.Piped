using Materialize.Reify.Mods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Materialize.Reify
{
    class ReifyExecutor
    {
        IMod[] _mods;

        public ReifyExecutor(IEnumerable<IMod> mods) {
            _mods = mods.ToArray();
        }

        public object Execute(IQueryable qySource) 
        {
            //mods modify expression

            //get results from provider (unary possible)

            //mods modify reified

            //return

            throw new NotImplementedException();
        }
    }
}
