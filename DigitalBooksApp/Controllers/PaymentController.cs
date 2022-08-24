using DigitalBooksApp.DatabaseEntity;
using DigitalBooksApp.NewFolder;
using DigitalBooksApp.Service;
using Microsoft.AspNetCore.Mvc;

namespace DigitalBooksApp.Controllers
{
        [ApiController]
        [Route("[controller]")]
        public class PaymentController : ControllerBase
        {
            private readonly IPaymentService _ipaymentService;
            public PaymentController(IPaymentService ipaymentService)
            {
            _ipaymentService = ipaymentService;
            }
            [HttpGet]
            public ActionResult GetAllPaymentDetails()
            {
                return Ok(_ipaymentService.GetAllPaymentDetails());
            }
            [HttpPost("CreatePayment")]
            public ActionResult<string> CreatePayment([FromBody] PaymentDetails payment)
            {
                string result = _ipaymentService.CreatePayment(payment);
                return Ok(result);
            }
        }
}
