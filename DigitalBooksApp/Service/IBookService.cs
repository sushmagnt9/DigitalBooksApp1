using DigitalBooksApp.DatabaseEntity;

namespace DigitalBooksApp.Service
{
    public interface IBookService
    {
        string CreateBook(Book book);
        string DeleteBooks(int bookId);
        List<Book> GetAllBooks();
        List<Book> SearchBooks(Book book);
        string UpdateBooks(int bookId, Book books);
    }
}