using DigitalBooksApp.DatabaseEntity;
using DigitalBooksApp.Service;
using Microsoft.AspNetCore.Mvc;

namespace DigitalBooksApp.Controllers
{
    [Route("api/CreateAuthor")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorService _authorService;

            public AuthorController(IAuthorService authorService)
            {
                _authorService = authorService;
            }

            [HttpPost]
            public ActionResult<string> CreateAuthor([FromBody] User userDetails)
            {
                string result = _authorService.CreateAuthor(userDetails);
                return Ok(result);
            }
        }
}
