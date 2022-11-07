using Microsoft.AspNetCore.Mvc;
using News.Business.Services.Interfaces;
using News.Models;
using System.Threading.Tasks;

namespace News.Controllers
{
    public class AuthController : Controller
    {

        private readonly IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> LoginUserAsync(string userName, string password)
        {
            
            return View(await _authService.LoginAsync(userName, password));
        }
    }
}
