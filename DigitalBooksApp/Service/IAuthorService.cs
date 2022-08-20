using DigitalBooksApp.DatabaseEntity;

namespace DigitalBooksApp.Service
{
    public interface IAuthorService
    {
        DigitalbookContext _digitalBookContext { get; set; }

        string CreateAuthor(User author);
    }
}