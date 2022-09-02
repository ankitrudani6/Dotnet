using System;
using System.Collections.Generic;

#nullable disable

namespace AdvanceLINQPractice.Models
{
    public partial class VwFlightDetail
    {
        public int AirLineId { get; set; }
        public string AirLineName { get; set; }
        public string AirLineCode { get; set; }
        public int FlightCodeId { get; set; }
        public int FlightCode { get; set; }
        public int FlightId { get; set; }
        public TimeSpan? DepartureTime { get; set; }
        public TimeSpan? ArrivalTime { get; set; }
        public int? Duration { get; set; }
        public int? TotalSeats { get; set; }
        public int? SourceId { get; set; }
        public string Source { get; set; }
        public int? DestinationId { get; set; }
        public string Destination { get; set; }
    }
}
