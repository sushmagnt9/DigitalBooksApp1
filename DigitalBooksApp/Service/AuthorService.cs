using DigitalBooksApp.DatabaseEntity;

namespace DigitalBooksApp.Service
{
    public class AuthorService : IAuthorService
    {
        public DigitalbookContext _digitalBookContext { get; set; }
        public AuthorService(DigitalbookContext digitalBookContext)
        {
            _digitalBookContext = digitalBookContext;
        }

        /// <summary>
        /// This method will create account for author
        /// </summary>
        /// <param name="author">author</param>
        /// <returns>return a  message whether the author is created or not</returns>
        public string CreateAuthor(User author)
        {
            try
            {
                _digitalBookContext.Users.Add(author);
                _digitalBookContext.SaveChanges();
            }
            catch (Exception ex)
            {
                return $"Operation failed {ex.Message}";
            }
            return $"Author account for {author.UserName} created successfully";
        }
    }
}
   
