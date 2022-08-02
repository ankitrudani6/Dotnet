using System;
using System.Collections.Generic;

#nullable disable

namespace ToyCompanyAPI.Models
{
    public partial class CustomerAddress
    {
        public int CustomerAddressId { get; set; }
        public int? CustomerId { get; set; }
        public int? AddressId { get; set; }
        public bool? IsDefault { get; set; }

        public virtual Address Address { get; set; }
        public virtual Customer Customer { get; set; }
    }
}
