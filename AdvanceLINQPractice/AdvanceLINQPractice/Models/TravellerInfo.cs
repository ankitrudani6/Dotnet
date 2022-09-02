using System;
using System.Collections.Generic;

#nullable disable

namespace AdvanceLINQPractice.Models
{
    public partial class TravellerInfo
    {
        public TravellerInfo()
        {
            FlightBookingLines = new HashSet<FlightBookingLine>();
        }

        public int TravellerId { get; set; }
        public int? UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? BirthDate { get; set; }
        public string Gender { get; set; }
        public string MaritalStatus { get; set; }
        public string PassportNumber { get; set; }
        public int? IssuingCountryId { get; set; }
        public DateTime? ExpiredDate { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }

        public virtual Country IssuingCountry { get; set; }
        public virtual LoginInfo User { get; set; }
        public virtual ICollection<FlightBookingLine> FlightBookingLines { get; set; }
    }
}
