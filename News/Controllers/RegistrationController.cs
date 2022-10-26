using Microsoft.AspNetCore.Mvc;

namespace News.Controllers
{
    public class RegistrationController : Controller
    {
        public IActionResult Index()
        {

            return View();
        }

        [HttpPost]
        public IActionResult Index(string login, string password)
        {
            return View();
        }
    }
}
