using DigitalBooksApp.DatabaseEntity;
using DigitalBooksApp.NewFolder;

namespace DigitalBooksApp.Service
{
    public class BookService : IBookService
    {
        private readonly DigitalbookContext _digitalbookContext;
        public BookService(DigitalbookContext digitalBookContext)
        {
            _digitalbookContext = digitalBookContext;
        }
        public List<Book> GetAllBooks()
        {
            return _digitalbookContext.Books.ToList();
        }
        public string CreateBook(BookDetails book)
        {
            try
            {
                Book bookDetails = new Book();
                bookDetails.BookTitle = book.BookTitle;
                bookDetails.Category = book.Category;
                bookDetails.UserId = book.UserId;
                bookDetails.CreatedDate = DateTime.UtcNow;
                bookDetails.ModifiedDate = DateTime.UtcNow;
                bookDetails.Price = book.price;
                bookDetails.Publisher = book.Publisher;
                bookDetails.PublishedDate = book.PublishedDate;
                bookDetails.Content = book.Content;
                bookDetails.Active = book.Active;
                bookDetails.Logo = book.Logo;
                _digitalbookContext.Books.Add(bookDetails);
                _digitalbookContext.SaveChanges();
            }
            catch (Exception ex)
            {
                return $"Book Operation failed {ex.Message}";
            }
            return "Book Details saved sucessfully";

        }
        public string UpdateBooks(int bookId, Book books)
        {
            var book = _digitalbookContext.Books.Find(bookId);
            book.BookTitle = books.BookTitle;
            book.Content = books.Content;
            book.Price = books.Price;
            book.Category = books.Category;
            _digitalbookContext.SaveChanges();
            return $"Record is updated for {book.BookId}";

        }
        public string DeleteBooks(int bookId)
        {
            try
            {
                Book book = _digitalbookContext.Books.Find(bookId);
                if (bookId != null)
                {
                    _digitalbookContext.Books.Remove(book);
                    _digitalbookContext.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                return $"Book deletion failed {ex.Message}";
            }
            return $"{bookId} is deleted";
        }
    }
}
