using System;
using System.Collections.Generic;

#nullable disable

namespace AdvanceLINQPractice.Models
{
    public partial class Country
    {
        public Country()
        {
            TravellerInfos = new HashSet<TravellerInfo>();
        }

        public int CountryId { get; set; }
        public string CountryName { get; set; }
        public int? CountryCode { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }

        public virtual ICollection<TravellerInfo> TravellerInfos { get; set; }
    }
}
