using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Materialize.Demo
{
    abstract class Demo
    {
        public string Name { get; protected set; }
        public string Description { get; protected set; }
        public abstract void Run();
    }
}
