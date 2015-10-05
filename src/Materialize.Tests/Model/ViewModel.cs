using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Materialize.Tests.Model
{
    public class DogModel
    {
        public string Name { get; set; }
    }

    public class DogAndOwnerModel
    {
        [Key]
        public int ID { get; set; }

        public string Name { get; set; }
        public PersonModel Owner { get; set; }
    }

    
    public class PersonModel
    {
        public string Name { get; set; }
    }

    public class PersonWithPetsModel
    {
        public string Name { get; set; }
        public ICollection<DogModel> Dogs { get; set; }
    }

    
    public class DogGroomerModel
    {
        public string Name { get; set; }
    }

    public class ContractModel
    {
        public DogModel Dog { get; set; }
        public DogGroomerModel Groomer { get; set; }
        public Fee Fee { get; set; }
    }

    public struct Fee
    {
        public readonly decimal Amount;

        public Fee(decimal amount) {
            Amount = amount;
        }
    }

}
