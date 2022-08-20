using DigitalBooksApp.DatabaseEntity;
using DigitalBooksApp.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace DigitalBooksApp.Controllers
{
    
    [ApiController]
    [Route("[controller]")]
    public class UserController : Controller
    {
        private readonly IUserService _iUserService;
        public UserController (IUserService userService)
        {
            _iUserService = userService;
        }
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<User>>> GetAllUsers()
        //{
        //    var identity = HttpContext.User.Identity as ClaimsIdentity;
        //    if(identity != null)
        //    {
        //        IEnumerable<Claim> claims = identity.Claims;
        //        //string UserType = identity.FindFirst("User_Type").Value.ToString();
        //    }
        //    return await _iUserService.GetAllUsers.ToListAsync();
        //}
        [HttpGet]
        public ActionResult GetAllUsers()
        {
            return Ok(_iUserService.GetAllUsers());
        }
        [HttpPost]
        public ActionResult<string> CreateUser([FromBody]User user)
        {
            string result = _iUserService.CreateUser(user);
            return Ok(result);
        }
        [HttpPut("{userId}")]
        public ActionResult UpdateUsers(int userId, [FromBody] User user)
        {
            if (userId == user.UserId)
            {
                string result = _iUserService.UpdateUsers(userId, user);
            }
            return Ok();
        }
    }
}
