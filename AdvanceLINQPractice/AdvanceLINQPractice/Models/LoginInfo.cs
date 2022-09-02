using System;
using System.Collections.Generic;

#nullable disable

namespace AdvanceLINQPractice.Models
{
    public partial class LoginInfo
    {
        public LoginInfo()
        {
            FlightBookings = new HashSet<FlightBooking>();
            Payments = new HashSet<Payment>();
            TravellerInfos = new HashSet<TravellerInfo>();
        }

        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? BirthDate { get; set; }
        public string Gender { get; set; }
        public string EmailAddress { get; set; }
        public decimal? PhoneNumber { get; set; }
        public string Password { get; set; }
        public bool? IsAdmin { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }

        public virtual ICollection<FlightBooking> FlightBookings { get; set; }
        public virtual ICollection<Payment> Payments { get; set; }
        public virtual ICollection<TravellerInfo> TravellerInfos { get; set; }
    }
}
