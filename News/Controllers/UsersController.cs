using Microsoft.AspNetCore.Mvc;

namespace News.Controllers
{
    public class UsersController : Controller
    {
        public IActionResult UsersList()
        {
            return View();
        }
    }
}
