using System;
using System.Collections.Generic;

#nullable disable

namespace WebAPIDemo.Models
{
    public partial class Person
    {
        public int PersonId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? BirthDate { get; set; }
        public string Email { get; set; }
        public decimal? PhoneNumber { get; set; }
        public string City { get; set; }
    }
}
