namespace DigitalBooksApp.NewFolder
{
    public class BookDetails
    {
        public string BookTitle { get; set; } = null;
        public string Category { get; set; } = null;

        public decimal price { get;set; }
        public int UserId { get; set; }
        public string Publisher { get; set; } = null;
        public DateTime PublishedDate { get;set; }
        public string Content { get; set; } = null;
        public bool Active { get; set; }
        public string? Logo { get; set; }  

    }
}
