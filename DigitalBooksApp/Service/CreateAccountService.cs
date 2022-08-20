using DigitalBooksApp.DatabaseEntity;

namespace DigitalBooksApp.Service
{
    public class CreateAccountService
    {
        public DigitalbookContext todoContext { get; set; }
        public CreateAccountService(DigitalbookContext digitalBookContext)
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