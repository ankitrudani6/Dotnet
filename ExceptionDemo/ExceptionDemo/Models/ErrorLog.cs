using System;
using System.Collections.Generic;

#nullable disable

namespace ExceptionDemo.Models
{
    public partial class ErrorLog
    {
        public int ErrorId { get; set; }
        public string MessageTxt { get; set; }
    }
}
