using DigitalBooksApp.DatabaseEntity;

namespace DigitalBooksApp.Service
{
    public interface IPaymentService
    {
        string CreatePayment(Payment payment);
        List<Payment> GetAllPaymentDetails();
    }
}