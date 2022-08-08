using System;
using System.Collections.Generic;

#nullable disable

namespace MakeMyTripAPI.Models
{
    public partial class Country
    {
        public Country()
        {
            ProfileInfos = new HashSet<ProfileInfo>();
        }

        public int CountryId { get; set; }
        public string CountryName { get; set; }
        public string CountryCode { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }

        public virtual ICollection<ProfileInfo> ProfileInfos { get; set; }
    }
}
