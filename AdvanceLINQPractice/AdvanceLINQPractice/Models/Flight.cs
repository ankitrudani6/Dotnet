using System;
using System.Collections.Generic;

#nullable disable

namespace AdvanceLINQPractice.Models
{
    public partial class Flight
    {
        public Flight()
        {
            Schedules = new HashSet<Schedule>();
        }

        public int FlightId { get; set; }
        public int? FlightCodeId { get; set; }
        public int? SourceId { get; set; }
        public int? DestinationId { get; set; }
        public TimeSpan? DepartureTime { get; set; }
        public TimeSpan? ArrivalTime { get; set; }
        public int? Duration { get; set; }
        public int? TotalSeats { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }

        public virtual Location Destination { get; set; }
        public virtual FlightCode FlightCode { get; set; }
        public virtual Location Source { get; set; }
        public virtual ICollection<Schedule> Schedules { get; set; }
    }
}
