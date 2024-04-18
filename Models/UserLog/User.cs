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
            ID = userParams.ID;
            FName = userParams.FName;
            LName = userParams.LName;
            Role = userParams.Role;
            Rate = userParams.Rate;
        }
    }
}
