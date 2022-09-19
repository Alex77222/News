using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace News.Models 
{
    public class UserModel
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string HashPassword { get; set; }
        public string UserPic { get; set; }
    }
}
