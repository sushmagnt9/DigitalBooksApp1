using DigitalBooksApp.DatabaseEntity;

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
        public string CreatePayment(Payment payment)
        {
            try
            {
                Payment paymentDetails = new Payment();
                paymentDetails.Email = payment.Email;
                paymentDetails.PaymentDate = payment.PaymentDate;
                _digitalbookContext.Payments.Add(paymentDetails);
                _digitalbookContext.SaveChanges();
            }
            catch (Exception ex)
            {
                return $"Book Operation failed {ex.Message}";
            }
            return "Book Details saved sucessfully";

        }
    }
}
