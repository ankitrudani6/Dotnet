using System;
using System.Collections.Generic;

#nullable disable

namespace AdvanceLINQPractice.Models
{
    public partial class TravelClass
    {
        public TravelClass()
        {
            FlightBookings = new HashSet<FlightBooking>();
        }

        public int TravelClassId { get; set; }
        public string TravelClass1 { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }

        public virtual ICollection<FlightBooking> FlightBookings { get; set; }
    }
}
