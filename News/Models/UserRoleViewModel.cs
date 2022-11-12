using System.Collections.Generic;

namespace News.Models
{
    public class UserRoleViewModel
    {
        public IList<UserViewModel> Users { get; set; }
        public IList<string> AllRoles { get; set; }
    }
}
