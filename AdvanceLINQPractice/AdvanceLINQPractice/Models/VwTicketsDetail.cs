using System;
using System.Collections.Generic;

#nullable disable

namespace AdvanceLINQPractice.Models
{
    public partial class VwTicketsDetail
    {
        public int TicketId { get; set; }
        public string Pnrno { get; set; }
        public int? PaymentId { get; set; }
        public string TicketStatus { get; set; }
        public int? FlightBookingId { get; set; }
        public string PaymentStatus { get; set; }
        public int? UserId { get; set; }
        public int? ScheduleId { get; set; }
        public int? NoOfPassenger { get; set; }
        public decimal? PayableAmount { get; set; }
        public DateTime? DateOfBooking { get; set; }
        public DateTime? DepartureDate { get; set; }
    }
}
