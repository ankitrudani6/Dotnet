using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToyCompanyAPI.Models
{
    public class ManufacturingPlant
    {
        public ManufacturingPlant()
        {
            Toys = new HashSet<Toy>();
        }

        public int PlantId { get; set; }
        public string PlantName { get; set; }

        public virtual ICollection<Toy> Toys { get; set; }
    }
}
