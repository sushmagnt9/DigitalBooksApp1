using DigitalBooksApp.DatabaseEntity;

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
        public string CreateBook(Book book)
        {
            try
            {
                Book bookDetails = new Book();
                bookDetails.Title = book.Title;
                bookDetails.Logo = null;
                bookDetails.Category = book.Category;
                bookDetails.CreatedDate = DateTime.UtcNow;
                bookDetails.ModifiedDate = DateTime.UtcNow;
                bookDetails.Price = book.Price;
                bookDetails.AuthorName = book.AuthorName;
                bookDetails.Publisher = book.Publisher;
                bookDetails.PublishedDate = book.PublishedDate;
                bookDetails.Content = book.Content;
                bookDetails.Active = book.Active;
                _digitalbookContext.Books.Add(bookDetails);
                _digitalbookContext.SaveChanges();
            }
            catch (Exception ex)
            {
                return $"Book Operation failed {ex.Message}";
            }
            return "Book Details saved sucessfully";

        }
        public List<Book> SearchBooks(Book book)
        {
            return _digitalbookContext.Books.Where(x => (x.Title == book.Title && x.Price == book.Price || x.Category == book.Category || x.Publisher == book.Publisher || x.Content == book.Content)).ToList();
        }
        public string UpdateBooks(int bookId, Book books)
        {
            var book = _digitalbookContext.Books.Find(bookId);
            book.Title = books.Title;
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
