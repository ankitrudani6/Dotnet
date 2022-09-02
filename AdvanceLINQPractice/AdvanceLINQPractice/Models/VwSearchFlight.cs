using System;
using System.Collections.Generic;

#nullable disable

namespace AdvanceLINQPractice.Models
{
    public partial class VwSearchFlight
    {
        public int ScheduleId { get; set; }
        public string AirLineName { get; set; }
        public string AirLineCode { get; set; }
        public string LogoUrl { get; set; }
        public int FlightCode { get; set; }
        public decimal BaseFare { get; set; }
        public decimal Surcharges { get; set; }
        public decimal? Total { get; set; }
        public DateTime? DepartureDate { get; set; }
        public int? AvailableSeats { get; set; }
        public int? TotalSeats { get; set; }
        public string Source { get; set; }
        public string Destination { get; set; }
        public TimeSpan? DepartureTime { get; set; }
        public TimeSpan? ArrivalTime { get; set; }
        public int? Duration { get; set; }
    }
}
