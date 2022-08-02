using System;
using System.Collections.Generic;

#nullable disable

namespace MiddlewareDemo.Models
{
    public partial class ExceptionLogging
    {
        public long Logid { get; set; }
        public string ExceptionMsg { get; set; }
        public string ExceptionType { get; set; }
        public string ExceptionSource { get; set; }
        public string ExceptionUrl { get; set; }
        public DateTime? Logdate { get; set; }
    }
}
