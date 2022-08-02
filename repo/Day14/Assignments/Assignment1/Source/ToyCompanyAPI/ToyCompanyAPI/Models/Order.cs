using System;
using System.Collections.Generic;

#nullable disable

namespace ToyCompanyAPI.Models
{
    public partial class Order
    {
        public Order()
        {
            OrderToys = new HashSet<OrderToy>();
        }

        public int OrderId { get; set; }
        public DateTime? OrderDate { get; set; }
        public int? CustomerId { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual ICollection<OrderToy> OrderToys { get; set; }
    }
}
