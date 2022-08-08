using System;
using System.Collections.Generic;

#nullable disable

namespace MakeMyTripAPI.Models
{
    public partial class ProfileInfo
    {
        public ProfileInfo()
        {
            FlightBookingLines = new HashSet<FlightBookingLine>();
        }

        public int ProfileId { get; set; }
        public int? UserId { get; set; }
        public string FullName { get; set; }
        public DateTime? BirthDate { get; set; }
        public string Gender { get; set; }
        public string MaritalStatus { get; set; }
        public string PassportNumber { get; set; }
        public int? IssuingCountryId { get; set; }
        public DateTime? ExpiredDate { get; set; }
        public bool? IsTraveller { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }

        public virtual Country IssuingCountry { get; set; }
        public virtual LoginInfo User { get; set; }
        public virtual ICollection<FlightBookingLine> FlightBookingLines { get; set; }
    }
}
