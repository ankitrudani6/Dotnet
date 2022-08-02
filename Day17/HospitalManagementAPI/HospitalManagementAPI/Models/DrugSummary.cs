using System;
using System.Collections.Generic;

#nullable disable

namespace HospitalManagementAPI.Models
{
    public partial class DrugSummary
    {
        public int Id { get; set; }
        public int? PatientId { get; set; }
        public int? DrugId { get; set; }
        public string Time { get; set; }

        public virtual Drug Drug { get; set; }
        public virtual Patient Patient { get; set; }
    }
}
