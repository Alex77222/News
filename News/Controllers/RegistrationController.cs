using Microsoft.AspNetCore.Mvc;
using News.Business.Services.Interfaces;
using News.Models;
using System.Threading.Tasks;

namespace News.Controllers
{
    public class RegistrationController : Controller
    {

        private readonly IAuthService _authService;
        public RegistrationController(IAuthService authService)
        {
            _authService = authService;
        }
        public IActionResult Registration()
        {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> LoginAsync(UserViewModel user)
        {
            await _authService.LoginAsync(user.UserName,user.HashPassword);
            return View();
        }
    }
}
