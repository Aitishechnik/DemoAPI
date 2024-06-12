using DemoAPI.Data.Entities;
using DemoAPI.Models;
using System.Diagnostics.Eventing.Reader;

namespace DemoAPI.Services
{
    public interface IUserLogService
    {
        Task<List<UserEntity>> ShowUserList();
        Task<bool> AddNewUser(UserParams userParams);
        Task<bool> UpdateUserInfo(long id, UserParams userUpdateInfo);
        Task<bool> DeleteUser(long id);
        Task<bool> AddNewUserLog(string name);
    }
}
