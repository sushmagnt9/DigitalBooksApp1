using System;
using System.Collections.Generic;

namespace DigitalBooksApp.DatabaseEntity
{
    public partial class Payment
    {
        public int PaymentId { get; set; }
        public string? BuyerEmail { get; set; }
        public string? BuyerName { get; set; }
        public long BookId { get; set; }
        public DateTime PaymentDate { get; set; }

        public virtual Book Book { get; set; } = null!;
    }
}
