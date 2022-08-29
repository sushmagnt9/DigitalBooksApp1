using DigitalBooksApp.DatabaseEntity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using TokenAuthentication.Model;

namespace TokenAuthentication.Service
{
    public class TokenService : ITokenService
    {
        private readonly DigitalbookContext _digitalBookContext;
        public TokenService(DigitalbookContext digitalBookContext)
        {
            _digitalBookContext = digitalBookContext;
        }
        public bool ValidateUser(UserValidationRequestModel usercreds)
        {
            var authorObj = _digitalBookContext.Users.Where(u => u.UserName == usercreds.UserName && u.Password == usercreds.Password && u.UserRole == usercreds.UserRole).Count();
            if (authorObj >0 )
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private TimeSpan ExpiryDuration = new TimeSpan(20, 30, 0);
        public string BuildToken(string Key, string Issuer, IEnumerable<string> Audience, string userName)
        {
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.UniqueName,userName)
                //new Claim("Name",user.UserName),
                //new Claim("password",user.Password)
            };
            claims.AddRange(Audience.Select(aud => new Claim(JwtRegisteredClaimNames.Aud, aud)));
            var SecurityKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Key));
            var credentials = new SigningCredentials(SecurityKey, SecurityAlgorithms.HmacSha256);
            var TokenDescriptor = new JwtSecurityToken(Issuer, Issuer, claims, expires: DateTime.Now.Add(ExpiryDuration), signingCredentials: credentials);
            return new JwtSecurityTokenHandler().WriteToken(TokenDescriptor);
        }


    }
}
