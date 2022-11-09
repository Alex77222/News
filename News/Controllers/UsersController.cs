using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using News.Business.Services.Interfaces;
using News.Data;
using System.Threading.Tasks;

namespace News.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUserService _userService;
        public UsersController(IUserService userService)
        {
            _userService = userService;
        }   

        public async Task<IActionResult> UserAsync()
        {
            return View(await _userService.GetListUserAsync());
        }
        public async Task<IActionResult> DeleteAsync(int id)
        {
            await _userService.DeleteUserListAsync(id);
            return RedirectToAction("User");
        }
    }
}
