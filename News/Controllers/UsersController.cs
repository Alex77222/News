using Microsoft.AspNetCore.Mvc;
using News.Business.Services.Interfaces;
using News.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace News.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUserService _userService;
        private readonly IRoleService _roleService;
        public UsersController(IUserService userService, IRoleService roleService)
        {
            _userService = userService;
            _roleService = roleService;
        }

        public async Task<IActionResult> UserAsync()
        {
            var userRoleViewModel = new UserRoleViewModel
            {
                Users = await _userService.GetListUserAsync(),
                AllRoles = (await _roleService.GetListRoleAsync()).Select(x => x.Name).ToList(),
            };
            return View(userRoleViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> UserUpdateRoleAsync(string userName,List<string> comingRoles)
        {
            await _roleService.UpdateRoleAsync(userName, comingRoles);
            return RedirectToAction("User");
        }
      
        
    }
}
