using System;
using System.Collections.Generic;

#nullable disable

namespace AdvanceLINQPractice.Models
{
    public partial class FlightCode
    {
        public FlightCode()
        {
            Flights = new HashSet<Flight>();
        }

        public int FlightCodeId { get; set; }
        public int? AirLineId { get; set; }
        public int FlightCode1 { get; set; }

        public virtual Airline AirLine { get; set; }
        public virtual ICollection<Flight> Flights { get; set; }
    }
}
