using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

namespace News.Models
{
    public class UserRoleViewModel:PageModel
    {
        public IList<UserViewModel> Users { get; set; }
        public IList<string> AllRoles { get; set; }
        public bool IsCheecked { get; set; }
        public string userName { get; set; }
    }
}
