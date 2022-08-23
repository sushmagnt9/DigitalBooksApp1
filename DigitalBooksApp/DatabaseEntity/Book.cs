using System;
using System.Collections.Generic;

namespace DigitalBooksApp.DatabaseEntity
{
    public partial class Book
    {
        public Book()
        {
            Payments = new HashSet<Payment>();
        }

        public long BookId { get; set; }
        public string? Logo { get; set; }
        public string BookTitle { get; set; } = null!;
        public string? Category { get; set; }
        public decimal? Price { get; set; }
        public int UserId { get; set; }
        public string? Publisher { get; set; }
        public DateTime? PublishedDate { get; set; }
        public string? Content { get; set; }
        public bool? Active { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }

        public virtual User User { get; set; } = null!;
        public virtual ICollection<Payment> Payments { get; set; }
    }
}
