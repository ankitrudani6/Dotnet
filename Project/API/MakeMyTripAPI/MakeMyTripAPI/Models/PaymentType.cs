using System;
using System.Collections.Generic;

#nullable disable

namespace MakeMyTripAPI.Models
{
    public partial class PaymentType
    {
        public PaymentType()
        {
            Payments = new HashSet<Payment>();
        }

        public int PaymentTypeId { get; set; }
        public string PaymentTypeName { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }

        public virtual ICollection<Payment> Payments { get; set; }
    }
}
