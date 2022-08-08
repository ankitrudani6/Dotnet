using System;
using System.Collections.Generic;

#nullable disable

namespace MakeMyTripAPI.Models
{
    public partial class Location
    {
        public Location()
        {
            FlightDestinations = new HashSet<Flight>();
            FlightSources = new HashSet<Flight>();
        }

        public int LocationId { get; set; }
        public string LocationName { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }

        public virtual ICollection<Flight> FlightDestinations { get; set; }
        public virtual ICollection<Flight> FlightSources { get; set; }
    }
}
