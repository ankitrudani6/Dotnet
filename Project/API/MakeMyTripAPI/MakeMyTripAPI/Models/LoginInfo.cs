using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

#nullable disable

namespace MakeMyTripAPI.Models
{
    public partial class LoginInfo
    {
        public LoginInfo()
        {
            ProfileInfos = new HashSet<ProfileInfo>();
        }

        public int UserId { get; set; }
        public string EmailAddress { get; set; }
        public decimal? PhoneNumber { get; set; }
        public string Password { get; set; }
        [JsonIgnore]
        public bool? IsAdmin { get; set; }
        [JsonIgnore]
        public bool? IsActive { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }

        public virtual ICollection<ProfileInfo> ProfileInfos { get; set; }
    }
}
