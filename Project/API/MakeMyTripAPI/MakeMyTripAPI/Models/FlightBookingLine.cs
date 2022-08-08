using System;
using System.Collections.Generic;

#nullable disable

namespace MakeMyTripAPI.Models
{
    public partial class FlightBookingLine
    {
        public int FlightBookingLineId { get; set; }
        public int? FlightBookingId { get; set; }
        public int? ProfileId { get; set; }
        public int? PassengerTypeId { get; set; }
        public string SeatNumber { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }

        public virtual FlightBooking FlightBooking { get; set; }
        public virtual PassengerType PassengerType { get; set; }
        public virtual ProfileInfo Profile { get; set; }
    }
}
