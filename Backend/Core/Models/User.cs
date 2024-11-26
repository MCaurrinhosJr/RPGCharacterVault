namespace Core.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool UserConfirmed { get; set; }

    }

    public class UserAccess
    {
        public string Email { set; get; }
        public string Password { set; get; }
    }
}
