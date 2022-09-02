using System;
using System.Collections.Generic;

#nullable disable

namespace AdvanceLINQPractice.Models
{
    public partial class Discount
    {
        public Discount()
        {
            FlightBookings = new HashSet<FlightBooking>();
        }

        public int DiscountId { get; set; }
        public string DiscountCode { get; set; }
        public int? DiscountPer { get; set; }
        public string DiscountDiscription { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? ExpriedDate { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }

        public virtual ICollection<FlightBooking> FlightBookings { get; set; }
    }
}
