using System;
using System.Collections.Generic;

#nullable disable

namespace HospitalManagementAPI.Models
{
    public partial class ExceptionLogging
    {
        public long ErrorId { get; set; }
        public string ExceptionMsg { get; set; }
        public string StackTrace { get; set; }
        public string ExceptionSource { get; set; }
        public string Targetsite { get; set; }
        public DateTime? Logdate { get; set; }
    }
}
