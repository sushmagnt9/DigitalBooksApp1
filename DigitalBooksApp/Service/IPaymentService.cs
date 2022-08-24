using DigitalBooksApp.DatabaseEntity;
using DigitalBooksApp.NewFolder;

namespace DigitalBooksApp.Service
{
    public interface IPaymentService
    {
        string CreatePayment(PaymentDetails payment);
        List<Payment> GetAllPaymentDetails();
    }
}