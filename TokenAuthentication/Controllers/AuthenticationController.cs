using DigitalBooksApp.DatabaseEntity;
using Microsoft.AspNetCore.Mvc;
using TokenAuthentication.Model;
using TokenAuthentication.Service;

namespace TokenAuthentication.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class AuthenticationController: ControllerBase
    {
        private readonly ITokenService _tokenService;
        private readonly IConfiguration _configuration;
        public AuthenticationController(IConfiguration configuration,ITokenService tokenService)
        {
            this._configuration = configuration?? throw new ArgumentNullException(nameof(configuration));
            _tokenService = tokenService;
        }
        [HttpPost("validate")]
        public ActionResult<string> validate(UserValidationRequestModel usercreds)
        {
            try
            {
                if (_tokenService.ValidateUser(usercreds))
                {
                    var Token = _tokenService.BuildToken(_configuration["Jwt:Key"],
                                                     _configuration["Jwt:Issuer"],
                                                     new[]
                                                     {
                                                     _configuration["Jwt:Aud1"]
                                                     },
                                                     usercreds.UserName);
                    return Ok(new
                    {
                        Token = Token,
                        IsAuthenticated = true
                    });
                }
                return Ok(new
                {
                    Token = string.Empty,
                    IsAuthenticated = false
                });
            }
            catch(Exception ex)
            {
                return Unauthorized();
            }
        }
    }
}
