using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace TokenAuthentication.Service
{
    public class TokenService : ITokenService
    {
        private TimeSpan ExpiryDuration = new TimeSpan(20, 30, 0);
        public string BuildToken(string Key, string Issuer, IEnumerable<string> Audience, string userName)
        {
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.UniqueName,userName)
                //new Claim("Password","1234"),
                //new Claim("UserType","Author")
            };
            claims.AddRange(Audience.Select(aud => new Claim(JwtRegisteredClaimNames.Aud, aud)));
            var SecurityKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Key));
            var credentials = new SigningCredentials(SecurityKey, SecurityAlgorithms.HmacSha256);
            var TokenDescriptor = new JwtSecurityToken(Issuer, Issuer, claims, expires:DateTime.Now.Add(ExpiryDuration), signingCredentials:credentials);
            return new JwtSecurityTokenHandler().WriteToken(TokenDescriptor);
        }
    }
}
