﻿using System;
using System.Collections.Generic;

#nullable disable

namespace ToyCompany.Models
{
    public partial class Customer
    {
        public Customer()
        {
            Orders = new HashSet<Order>();
        }

        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public DateTime? Dob { get; set; }
        public string Email { get; set; }
        public decimal? PhoneNumber { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
