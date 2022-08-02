using System;
using System.Collections.Generic;

#nullable disable

namespace ToyCompany.Models
{
    public partial class OrderToy
    {
        public int OrderToyId { get; set; }
        public int? OrderId { get; set; }
        public int? ToyId { get; set; }
        public int? Qty { get; set; }

        public virtual Order Order { get; set; }
        public virtual Toy Toy { get; set; }
    }
}
