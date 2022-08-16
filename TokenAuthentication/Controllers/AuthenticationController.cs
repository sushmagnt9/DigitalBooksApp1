using DigitalBooksApp.DatabaseEntity;
using Microsoft.AspNetCore.Mvc;
using TokenAuthentication.Service;

namespace TokenAuthentication.Controllers
{
    public class AuthenticationController: ControllerBase
    {
        private readonly ITokenService _tokenService;
        private readonly IConfiguration _configuration;
        public AuthenticationController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        [HttpPost("validate")]
        public ActionResult<string> validate(User user)
        {
            var authorObj = _tokenService.ValidateUser(user);
            if(authorObj != null)
            {
                return _tokenService.BuildToken(_configuration["Jwt:Key"],
                                                 _configuration["Jwt:Issuer"],
                                                 new[]
                                                 {
                                                     _configuration["Jwt:Aud1"],
                                                     _configuration["Jwt:Aud2"]
                                                 },
                                                 authorObj);
            }
            else
            {
                return Unauthorized();
            }
        }
    }
}
