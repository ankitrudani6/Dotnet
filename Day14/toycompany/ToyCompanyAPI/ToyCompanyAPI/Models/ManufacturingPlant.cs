using System;
using System.Collections.Generic;

#nullable disable

namespace ToyCompanyAPI.Models
{
    public partial class ManufacturingPlant
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
