using System;
using System.Collections.Generic;

#nullable disable

namespace MakeMyTripAPI.Models
{
    public partial class Payment
    {
        public int PaymentId { get; set; }
        public int? FlightBookingId { get; set; }
        public int? PaymentTypeId { get; set; }
        public string PaymentStatus { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }

        public virtual FlightBooking FlightBooking { get; set; }
        public virtual PaymentType PaymentType { get; set; }
    }
}
