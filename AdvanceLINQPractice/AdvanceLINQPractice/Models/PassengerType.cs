using System;
using System.Collections.Generic;

#nullable disable

namespace AdvanceLINQPractice.Models
{
    public partial class PassengerType
    {
        public PassengerType()
        {
            FlightBookingLines = new HashSet<FlightBookingLine>();
        }

        public int PassengerTypeId { get; set; }
        public string PassengerType1 { get; set; }
        public int? AgeFrom { get; set; }
        public int? AgeUpto { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }

        public virtual ICollection<FlightBookingLine> FlightBookingLines { get; set; }
    }
}
