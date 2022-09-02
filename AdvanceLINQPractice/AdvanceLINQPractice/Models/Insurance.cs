using System;
using System.Collections.Generic;

#nullable disable

namespace AdvanceLINQPractice.Models
{
    public partial class Insurance
    {
        public int InsuranceId { get; set; }
        public string InsuranceName { get; set; }
        public decimal Charge { get; set; }
    }
}
