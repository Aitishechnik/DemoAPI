using DemoAPI.Utilities;
using System.Text.Json.Serialization;

namespace DemoAPI.Models
{
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
