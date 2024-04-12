using DemoAPI.Models;
namespace DemoAPI.Services
{
    public interface IUserLogService
    {
        List<User> ShowUserList();
        bool AddNewUser(UserParams userParams);
        bool UpdateUserInfo(long id, User user);
        bool DeleteUser(long id);
    }
}
