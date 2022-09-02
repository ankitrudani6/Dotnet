using System;
using System.Collections.Generic;

#nullable disable

namespace AdvanceLINQPractice.Models
{
    public partial class Airline
    {
        public Airline()
        {
            FlightCodes = new HashSet<FlightCode>();
        }

        public int AirLineId { get; set; }
        public string AirLineName { get; set; }
        public string AirLineCode { get; set; }
        public string LogoUrl { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }

        public virtual ICollection<FlightCode> FlightCodes { get; set; }
    }
}
