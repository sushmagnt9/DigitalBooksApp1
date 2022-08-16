using System;
using System.Collections.Generic;

namespace DigitalBooksApp.DatabaseEntity
{
    public partial class Payment
    {
        public int PaymentId { get; set; }
        public string Email { get; set; } = null!;
        public int UserId { get; set; }
        public int BookId { get; set; }
        public DateTime PaymentDate { get; set; }
    }
}
