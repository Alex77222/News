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
        public async Task<IActionResult> DeleteAsync(int id)
        {
            await _userService.DeleteUserListAsync(id);
            return RedirectToAction("User");
        }

        public async Task<IActionResult> AddRoleAsync(string userName, List<string> roles)
        {
            foreach (var role in roles)
            {
                await _roleService.AssignRoleByUserAsync(userName, role);
            }
            
            return RedirectToAction("User");
        }
        
    }
}
