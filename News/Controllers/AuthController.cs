using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using News.Business.Services.Interfaces;
using News.Models;
using System.Security.Claims;
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

      
        public async Task<IActionResult> LoginUserAsync(string userName, string password)
        {
            
            var claims =  await _authService.LoginAsync(userName, password);
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claims));
            return RedirectPermanent("~/Home/Index");
        }
        
        public async Task<IActionResult> RegisterUserAsync(string userName, string password)
        {
            await _authService.RegisterUserAsync(userName,password);
            return RedirectPermanent("~/Home/Index");
        }
    }
}
