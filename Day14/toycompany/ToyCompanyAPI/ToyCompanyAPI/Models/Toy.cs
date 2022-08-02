using System;
using System.Collections.Generic;

#nullable disable

namespace ToyCompanyAPI.Models
{
    public partial class Toy
    {
        public Toy()
        {
            OrderToys = new HashSet<OrderToy>();
        }

        public int ToyId { get; set; }
        public string ToyName { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int? PlantId { get; set; }
        public int? ToyTypeId { get; set; }

        public virtual ManufacturingPlant Plant { get; set; }
        public virtual ToyType ToyType { get; set; }
        public virtual ICollection<OrderToy> OrderToys { get; set; }
    }
}
