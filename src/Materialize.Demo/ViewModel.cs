using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Materialize.Demo
{

    class RabbitVendorModel
    {
        public string Name { get; set; }
        public TownModel Town { get; set; }
        public RabbitModel RabbitForSale { get; set; }
    }

    class RabbitModel
    {
        public string Name { get; set; }
        public RabbitBreedModel Breed { get; set; }
        public CurrencyAmount Price { get; set; }
    }

    class TownModel
    {
        public string Name { get; set; }
    }

    class RabbitBreedModel
    {
        public string Name { get; set; }
        //public string FullName { get; set; }
    }

    
}
