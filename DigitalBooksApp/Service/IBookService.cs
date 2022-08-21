using DigitalBooksApp.DatabaseEntity;
using DigitalBooksApp.NewFolder;

namespace DigitalBooksApp.Service
{
    public interface IBookService
    {
        string CreateBook(BookDetails book);
        string DeleteBooks(int bookId);
        List<Book> GetAllBooks();
        string UpdateBooks(int bookId, Book books);
    }
}