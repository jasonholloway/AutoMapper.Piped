using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Materialize.Tests.Model
{
    public class Dog
    {
        [Key]
        public int ID { get; set; }

        string _name;

        public string Name {
            get { return _name; }
            set { _name = value; }
        }

        public int Age { get; set; }
        public Person Owner { get; set; }
    }

    public class Person
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public ICollection<Dog> Dogs { get; set; }
    }

    
    public class DogGroomer
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
    }


    public class Contract
    {
        [Key]
        public int ID { get; set; }
        public Dog Dog { get; set; }
        public DogGroomer Groomer { get; set; }
        public decimal Fee { get; set; }
    }



}
