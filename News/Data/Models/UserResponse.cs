namespace News.Data.Models
{
    public class UserResponse
    {
        public int Id { get; set; }
        public string UserName { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty ;
        public string RoleName { get; set; } = string.Empty;
    }
}
