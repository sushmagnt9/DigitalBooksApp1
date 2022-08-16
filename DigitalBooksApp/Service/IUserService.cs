using DigitalBooksApp.DatabaseEntity;

namespace DigitalBooksApp.Service
{
    public interface IUserService
    {
        string CreateUser(User user);
        List<User> GetAllUsers();
        string UpdateUsers(int userId, User users);
    }
}