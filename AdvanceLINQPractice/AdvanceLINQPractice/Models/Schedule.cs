using System;
using System.Collections.Generic;

#nullable disable

namespace AdvanceLINQPractice.Models
{
    public partial class Schedule
    {
        public Schedule()
        {
            FlightBookings = new HashSet<FlightBooking>();
        }

        public int ScheduleId { get; set; }
        public int? FlightId { get; set; }
        public DateTime? DepartureDate { get; set; }
        public decimal BaseFare { get; set; }
        public decimal Surcharges { get; set; }
        public decimal? Total { get; set; }
        public int? AvailableSeats { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }

        public virtual Flight Flight { get; set; }
        public virtual ICollection<FlightBooking> FlightBookings { get; set; }
    }
}
