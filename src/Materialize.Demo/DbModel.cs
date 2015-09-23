using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Materialize.Demo
{

    class Rabbit
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public RabbitBreed Breed { get; set; }
    }
    
    class RabbitVendor
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public Town Town { get; set; }
        public Rabbit RabbitOnOffer { get; set; }
    }
    
    class Town
    {
        public Town() {
            Vendors = new List<RabbitVendor>();
        }

        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public ICollection<RabbitVendor> Vendors { get; set; }
    }

    class RabbitBreed
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
    }

}
