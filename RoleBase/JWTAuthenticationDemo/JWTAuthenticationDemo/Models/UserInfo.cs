using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

#nullable disable

namespace JWTAuthenticationDemo.Models
{
    public partial class UserInfo
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public decimal PhoneNumber { get; set; }
        public string Password { get; set; }
        [JsonIgnore]
        public bool? IsAdmin { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
