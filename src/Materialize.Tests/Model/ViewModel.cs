using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Materialize.Tests.Model
{
    class DogModel
    {
        public string Name { get; set; }
    }

    class DogAndOwnerModel
    {
        public string Name { get; set; }
        public PersonModel Owner { get; set; }
    }

    
    class PersonModel
    {
        public string Name { get; set; }
    }
    
    class DogGroomerModel
    {
        public string Name { get; set; }
    }

    class ContractModel
    {
        public DogModel Dog { get; set; }
        public DogGroomerModel Groomer { get; set; }
        public Fee Fee { get; set; }
    }

    struct Fee
    {
        public readonly decimal Amount;

        public Fee(decimal amount) {
            Amount = amount;
        }
    }

}
