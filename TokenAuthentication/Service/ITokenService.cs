using DigitalBooksApp.DatabaseEntity;
using TokenAuthentication.Model;

namespace TokenAuthentication.Service
{
    public interface ITokenService
    {
        string BuildToken(string Key, string Issuer, IEnumerable<string> Audience, string userName);
        bool ValidateUser(UserValidationRequestModel usercreds);
    }
}