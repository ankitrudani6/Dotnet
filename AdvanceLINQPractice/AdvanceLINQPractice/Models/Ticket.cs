using System;
using System.Collections.Generic;

#nullable disable

namespace AdvanceLINQPractice.Models
{
    public partial class Ticket
    {
        public int TicketId { get; set; }
        public string Pnrno { get; set; }
        public int? PaymentId { get; set; }
        public string TicketStatus { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? ModifyAt { get; set; }

        public virtual Payment Payment { get; set; }
    }
}
