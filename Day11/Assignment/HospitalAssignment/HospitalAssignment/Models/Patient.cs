using System;
using System.Collections.Generic;

#nullable disable

namespace HospitalAssignment.Models
{
    public partial class Patient
    {
        public Patient()
        {
            DrugSummaries = new HashSet<DrugSummary>();
        }

        public int PatientId { get; set; }
        public string PatientName { get; set; }
        public int? Age { get; set; }
        public string Gender { get; set; }
        public int? DoctorId { get; set; }
        public int? AssistantId { get; set; }

        public virtual Assistant Assistant { get; set; }
        public virtual Doctor Doctor { get; set; }
        public virtual ICollection<DrugSummary> DrugSummaries { get; set; }
    }
}
