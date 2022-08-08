using System;
using System.Collections.Generic;

#nullable disable

namespace MakeMyTripAPI.Models
{
    public partial class TripType
    {
        public TripType()
        {
            FlightBookings = new HashSet<FlightBooking>();
        }

        public int TripTypeId { get; set; }
        public string TripTypeName { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }

        public virtual ICollection<FlightBooking> FlightBookings { get; set; }
    }
}
