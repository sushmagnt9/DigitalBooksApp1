using DigitalBooksApp.DatabaseEntity;
using DigitalBooksApp.NewFolder;

namespace DigitalBooksApp.Service
{
    public class PaymentService : IPaymentService
    {
        private readonly DigitalbookContext _digitalbookContext;
        public PaymentService(DigitalbookContext digitalBookContext)
        {
            _digitalbookContext = digitalBookContext;
        }
        public List<Payment> GetAllPaymentDetails()
        {
            return _digitalbookContext.Payments.ToList();
        }
        public string CreatePayment(PaymentDetails payment)
        {
            try
            {
                Payment paymentDetails = new Payment();
                paymentDetails.BuyerEmail = payment.BuyerEmail;
                paymentDetails.BuyerName = payment.BuyerName;
                paymentDetails.BookId = payment.BookId;
                paymentDetails.PaymentDate = payment.PaymentDate;
                _digitalbookContext.Payments.Add(paymentDetails);
                _digitalbookContext.SaveChanges();
            }
            catch (Exception ex)
            {
                return $"Payment Operation failed {ex.Message}";
            }
            return "payment Details saved sucessfully";

        }
    }
}
