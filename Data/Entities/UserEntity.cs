using DemoAPI.Models;

namespace DemoAPI.Data.Entities
{

    public class UserEntity : BaseEntity
    {
        public string? FName { get; set; }
        public string? LName { get; set; }
        public UserRole? Role { get; set; }
        public int? Rate { get; set; }
        public long? UserLogID { get; set; }
        public string? UserLogName { get; set; }

        public UserEntity() { }

        public UserEntity(UserParams userParams)
        {
            Id = userParams.ID;
            FName = userParams.FName;
            LName = userParams.LName;
            Role = userParams.Role;
            Rate = userParams.Rate;
            UserLogID = userParams.UserLogID; 
        }

        public void UpdateUser(UserParams userUpdateInfo)
        {
            if (userUpdateInfo.FName != null) FName = userUpdateInfo.FName;
            if (userUpdateInfo.LName != null) LName = userUpdateInfo.LName;
            if (userUpdateInfo.Role != null) Role = userUpdateInfo.Role;
            if (userUpdateInfo.Rate != null) Rate = userUpdateInfo.Rate;
            if (userUpdateInfo.UserLogID != null) UserLogID = userUpdateInfo.UserLogID;
        }
    }
}
