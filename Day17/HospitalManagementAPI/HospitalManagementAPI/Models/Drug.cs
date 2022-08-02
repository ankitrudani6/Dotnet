using System;
using System.Collections.Generic;

#nullable disable

namespace HospitalManagementAPI.Models
{
    public partial class Drug
    {
        public Drug()
        {
            DrugSummaries = new HashSet<DrugSummary>();
        }

        public int DrugId { get; set; }
        public string DrugName { get; set; }

        public virtual ICollection<DrugSummary> DrugSummaries { get; set; }
    }
}
