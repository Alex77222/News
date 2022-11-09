using System.Collections.Generic;

namespace News.Models
{
    public class UserViewModel
    {
        public int Id { get; set; } 
        public string UserName { get; set; }    
        public string HashPassword { get; set; }   
        public List<string>? Roles { get; set; }
    }
}
