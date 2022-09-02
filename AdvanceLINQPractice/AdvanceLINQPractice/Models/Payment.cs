using System;
using System.Collections.Generic;

#nullable disable

namespace AdvanceLINQPractice.Models
{
    public partial class Payment
    {
        public Payment()
        {
            Tickets = new HashSet<Ticket>();
        }

        public int PaymentId { get; set; }
        public int? UserId { get; set; }
        public int? FlightBookingId { get; set; }
        public int? PaymentTypeId { get; set; }
        public string PaymentStatus { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }

        public virtual FlightBooking FlightBooking { get; set; }
        public virtual PaymentType PaymentType { get; set; }
        public virtual LoginInfo User { get; set; }
        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}
