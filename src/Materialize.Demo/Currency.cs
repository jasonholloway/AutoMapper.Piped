using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Materialize.Demo
{
    class Currency
    {
        public string Name { get; private set; }
        public string Format { get; private set; }
        public decimal Ratio { get; private set; }

        public Currency(string name, string format, decimal ratio) {
            Name = name;
            Format = format;
            Ratio = ratio;
        }
    }
    
}
