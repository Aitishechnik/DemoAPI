using DemoAPI.Utilities;
using System.Text.Json.Serialization;

namespace DemoAPI.Models
{
    
    public class User
    {
        public long ID { get;}
        public string FName { get;}
        public string LName { get;}
        public UserRole Role { get;}
        public int Rate { get;}

        public User(UserParams userParams)
        {
            this.ID = userParams.ID;
            this.FName = userParams.FName;
            this.LName = userParams.LName;
            this.Role = userParams.Role;
            this.Rate = userParams.Rate;
        }
    }

    
    public class UserParams
    {
        public long ID { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
        public UserRole Role { get; set; }
        public int Rate { get; set; }
    }

    public class UserLog
    {
        public Dictionary<long, User> Users { get; } = [];
    }

    [JsonConverter(typeof(EnumStringConverter<UserRole>))]
    public enum UserRole
    {
        Intern,
        Specialist,
        Manager,
        Superviser,
        Admin,
    }
}
