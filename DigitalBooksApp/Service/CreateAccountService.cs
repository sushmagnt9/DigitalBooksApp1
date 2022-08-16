using DigitalBooksApp.DatabaseEntity;

namespace DigitalBooksApp.Service
{
    public class CreateAccountService
    {
        public DigitalBookContext todoContext { get; set; }
        public CreateAccountService(DigitalBookContext digitalBookContext)
        {
            todoContext = digitalBookContext;
        }
        public string AddBook(Book book)
        {
            todoContext.Books.Add(book);
            todoContext.SaveChanges();
            return "Sucess";

        }
    }
}