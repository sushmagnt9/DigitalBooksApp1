using DigitalBooksApp.DatabaseEntity;

namespace DigitalBooksApp.Service
{
    public interface IBookService
    {
        string CreateBook(Book book);
         List<Book> GetAllBooks();
         string UpdateBooks(int bookId, Book books);
         string DeleteBooks(int bookId);

    }
}