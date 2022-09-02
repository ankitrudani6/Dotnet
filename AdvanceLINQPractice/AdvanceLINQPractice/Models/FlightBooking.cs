using System;
using System.Collections.Generic;

#nullable disable

namespace AdvanceLINQPractice.Models
{
    public partial class FlightBooking
    {
        public FlightBooking()
        {
            FlightBookingLines = new HashSet<FlightBookingLine>();
            Payments = new HashSet<Payment>();
        }

        public int FlightBookingId { get; set; }
        public int? UserId { get; set; }
        public int? ScheduleId { get; set; }
        public int? TripTypeId { get; set; }
        public int? TravelClassId { get; set; }
        public int? NoOfPassenger { get; set; }
        public decimal? TotalFare { get; set; }
        public decimal? TotalSurcharge { get; set; }
        public bool? TravelInsurance { get; set; }
        public bool? CovidInsurance { get; set; }
        public decimal? TotalAmount { get; set; }
        public int? DiscountId { get; set; }
        public decimal? PayableAmount { get; set; }
        public string GstcompanyName { get; set; }
        public string GstregistrationNo { get; set; }
        public DateTime? DateOfBooking { get; set; }
        public string Status { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }

        public virtual Discount Discount { get; set; }
        public virtual Schedule Schedule { get; set; }
        public virtual TravelClass TravelClass { get; set; }
        public virtual TripType TripType { get; set; }
        public virtual LoginInfo User { get; set; }
        public virtual ICollection<FlightBookingLine> FlightBookingLines { get; set; }
        public virtual ICollection<Payment> Payments { get; set; }
    }
}
