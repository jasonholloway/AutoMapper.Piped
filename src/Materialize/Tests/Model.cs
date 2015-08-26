using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Materialize.Tests
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

}
