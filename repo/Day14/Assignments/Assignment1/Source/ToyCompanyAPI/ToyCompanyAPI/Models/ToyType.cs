using System;
using System.Collections.Generic;

#nullable disable

namespace ToyCompanyAPI.Models
{
    public partial class ToyType
    {
        public ToyType()
        {
            Toys = new HashSet<Toy>();
        }

        public int ToyTypeId { get; set; }
        public string TypeName { get; set; }

        public virtual ICollection<Toy> Toys { get; set; }
    }
}
