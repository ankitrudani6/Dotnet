using System;
using System.Collections.Generic;

#nullable disable

namespace MakeMyTripAPI.Models
{
    public partial class PassengerType
    {
        public PassengerType()
        {
            FlightBookingLines = new HashSet<FlightBookingLine>();
        }

        public int PassengerTypeId { get; set; }
        public string PassengerTypeName { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }

        public virtual ICollection<FlightBookingLine> FlightBookingLines { get; set; }
    }
}
