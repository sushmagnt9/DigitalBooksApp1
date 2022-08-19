using DigitalBooksApp.DatabaseEntity;

namespace DigitalBooksApp.Service
{
    public interface IAuthorService
    {
        DigitalBookContext _digitalBookContext { get; set; }

        string CreateAuthor(User author);
    }
}