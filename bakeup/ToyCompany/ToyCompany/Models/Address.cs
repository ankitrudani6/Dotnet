using System;
using System.Collections.Generic;

#nullable disable

namespace ToyCompany.Models
{
    public partial class Address
    {
        public Address()
        {
            Orders = new HashSet<Order>();
        }

        public int AddressId { get; set; }
        public string Address1 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int? PinCode { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
