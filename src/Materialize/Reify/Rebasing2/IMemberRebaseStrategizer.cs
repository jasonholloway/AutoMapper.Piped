using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Materialize.Reify.Rebasing2
{
    interface IMemberRebaseStrategizer
    {
        IRebaseStrategy GetStrategy(IRebaseStrategy strInst, MemberInfo member);
    }
}
