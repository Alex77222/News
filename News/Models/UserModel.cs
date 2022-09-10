using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace News.Models 
{
    public class UserModel
    {
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string HashPassword { get; set; }
        public string UserFoto { get; set; }
    }
}
