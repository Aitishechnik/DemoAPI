namespace DemoAPI.Models
{
    public class UserParams
    {
        public long ID { get; set; }
        public string? FName { get; set; }
        public string? LName { get; set; }
        public UserRole? Role { get; set; }
        public int? Rate { get; set; }
        public long? UserLogID { get; set; }
    }
}
