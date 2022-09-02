using System;
using System.Collections.Generic;

#nullable disable

namespace AdvanceLINQPractice.Models
{
    public partial class PaymentType
    {
        public PaymentType()
        {
            Payments = new HashSet<Payment>();
        }

        public int PaymentTypeId { get; set; }
        public string PaymentType1 { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }

        public virtual ICollection<Payment> Payments { get; set; }
    }
}
