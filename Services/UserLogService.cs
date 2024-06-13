using DemoAPI.Data;
using DemoAPI.Data.Entities;
using DemoAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace DemoAPI.Services
{
    public class UserLogService : IUserLogService
    {
        private DataContext _context;

        public UserLogService(DataContext context)
        {
            _context = context;
        }

        public async Task<bool> AddNewUser(UserParams userParams)
        {
            var user = await _context.UsersCustom.FirstOrDefaultAsync(u => u.Id == userParams.ID);
            if (user is null)
            {
                var newUser = new UserEntity(userParams);

                var log = await _context.UserLogs.FirstOrDefaultAsync(l => l.Id == userParams.UserLogID);

                if (log is null)
                {
                    return false;
                }
                newUser.UserLogName = log.Name;
                await _context.UsersCustom.AddAsync(newUser);
                await _context.SaveChangesAsync();

                return true;
            }

            return false;
        }

        public async Task<bool> AddNewUserLog(string name)
        {
            if (await _context.UserLogs.FirstOrDefaultAsync(user => user.Name == name) == null)
            {
                var newLog = new UserLogEntity
                {
                    Name = name
                };

                _context.UserLogs.Add(newLog);
                await _context.SaveChangesAsync();
                return true;
            }

            return false;
        }

        public async Task<bool> DeleteUser(long id)
        {
            var user = await _context.UsersCustom.FindAsync(id);
            if (user != null)
            {
                _context.UsersCustom.Remove(user);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<List<UserEntity>> ShowUserList()
        {
            return await _context.UsersCustom.ToListAsync();
        }

        public async Task<bool> UpdateUserInfo(long id, UserParams userUpdateInfo)
        {
            var log = await _context.UserLogs.FirstOrDefaultAsync(userLog => userLog.Id == userUpdateInfo.UserLogID);

            if(log == null)
                return false;

            var user = await _context.UsersCustom.FirstOrDefaultAsync(user => user.Id == userUpdateInfo.ID);
            if (user != null)
            {
                user.UpdateUser(userUpdateInfo);
                user.UserLogName = log.Name;
                _context.UsersCustom.Update(user);
                await _context.SaveChangesAsync();
                return true;
            }

            return false;
        }
    }
}
