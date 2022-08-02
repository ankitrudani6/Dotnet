using System;
using System.Collections.Generic;

#nullable disable

namespace ToyCompany.Models
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
        public int? AddressId { get; set; }

        public virtual Address Address { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual ICollection<OrderToy> OrderToys { get; set; }
    }
}
