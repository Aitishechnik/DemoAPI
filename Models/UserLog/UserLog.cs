namespace DemoAPI.Models
{
    public class UserLog
    {
        public Dictionary<long, User> Users { get; } = new Dictionary<long, User>();
    }
}
