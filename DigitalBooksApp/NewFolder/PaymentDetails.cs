namespace DigitalBooksApp.NewFolder
{
    public class PaymentDetails
    {
        public int PaymentId { get; set; }
        public string? BuyerEmail { get; set; }
        public string? BuyerName { get; set; }
        public int BookId { get; set; }
        public DateTime PaymentDate { get; set; }
    }
}
