using DemoAPI.Models;
namespace DemoAPI.Services
{
    public class UserLogService : IUserLogService
    {
        private UserLog userLog;

        public UserLogService(UserLog userLog)
        {
            this.userLog = userLog;
        }

        public bool AddNewUser(UserParams userParams)
        {
            if (!userLog.Users.ContainsKey(userParams.ID))
            {
                var user = new User(userParams);
                userLog.Users.Add(userParams.ID, user);
                return true;
            }

            return false;
        }

        public bool DeleteUser(long id)
        {
            if (userLog.Users.ContainsKey(id))
            {
                userLog.Users.Remove(id);
                return true;
            }
            return false;
        }

        public List<User> ShowUserList()
        {
            return userLog.Users.Values.ToList();
        }

        public bool UpdateUserInfo(long id, User user)
        {
            if (userLog.Users.ContainsKey(id))
            {
                userLog.Users[id] = user;
                return true;
            }

            return false;
        }
    }
}
