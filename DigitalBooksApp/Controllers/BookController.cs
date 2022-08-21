using DigitalBooksApp.DatabaseEntity;
using DigitalBooksApp.NewFolder;
using DigitalBooksApp.Service;
using Microsoft.AspNetCore.Mvc;

namespace DigitalBooksApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookController : ControllerBase
    {
        private readonly IBookService _ibookService;
        public BookController(IBookService ibookService)
        {
            _ibookService = ibookService;
        }
        [HttpGet]
        public ActionResult GetAllBooks()
        {
            return Ok(_ibookService.GetAllBooks());
        }
        [HttpPost("CreateBook")]
        public ActionResult<string> CreateBook([FromBody] BookDetails book)
        {
            string result = _ibookService.CreateBook(book);
            return Ok(result);
        }
        [HttpPut("{bookId}")]
        public ActionResult UpdateBooks(int bookId, [FromBody] Book book)
        {
            if (bookId == book.BookId)
            {
                string result = _ibookService.UpdateBooks(bookId, book);
            }
            return Ok();
        }
        [HttpDelete]
        public ActionResult DeleteBooks(int bookId)
        {
            string result = _ibookService.DeleteBooks(bookId);
            return Ok(result);
        }
    }
}
