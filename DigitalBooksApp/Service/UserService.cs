using DigitalBooksApp.DatabaseEntity;

namespace DigitalBooksApp.Service
{
    public class UserService : IUserService
    {
        private readonly DigitalbookContext _digitalbookContext;
        public UserService(DigitalbookContext digitalBookContext)
        {
            _digitalbookContext = digitalBookContext;
        }
        public List<User> GetAllUsers()
        {
            return _digitalbookContext.Users.ToList();
        }

        public string CreateUser(User user)
        {
            try
            {
                _digitalbookContext.Users.Add(user);
                _digitalbookContext.SaveChanges();
            }
            catch (Exception ex)
            {
                return $"User Operation failed {ex.Message}";
            }
            return "User Details saved sucessfully";

        }
        public string UpdateUsers(int userId, User users)
        {
            var user = _digitalbookContext.Users.Find(userId);
            user.UserId = users.UserId;
            user.UserName = users.UserName;
            user.UserRole = users.UserRole;
            user.Password = users.Password;
            _digitalbookContext.SaveChanges();
            return $"User is updated for {user.UserId}";

        }
    }
}

