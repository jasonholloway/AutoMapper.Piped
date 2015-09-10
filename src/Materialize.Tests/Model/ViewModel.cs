using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Materialize.Tests.Model
{
    internal class DogModel
    {
        public string Name { get; set; }
    }

    internal class DogAndOwnerModel
    {
        public string Name { get; set; }
        public PersonModel Owner { get; set; }
    }

    
    internal class PersonModel
    {
        public string Name { get; set; }
    }

    internal class PersonWithPetsModel
    {
        public string Name { get; set; }
        public ICollection<DogModel> Dogs { get; set; }
    }

    
    internal class DogGroomerModel
    {
        public string Name { get; set; }
    }

    internal class ContractModel
    {
        public DogModel Dog { get; set; }
        public DogGroomerModel Groomer { get; set; }
        public Fee Fee { get; set; }
    }

    internal struct Fee
    {
        public readonly decimal Amount;

        public Fee(decimal amount) {
            Amount = amount;
        }
    }

}
