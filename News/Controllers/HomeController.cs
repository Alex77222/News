using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using News.Models;

namespace News.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        { 
            return View(new List<UserModel>
            {
                new UserModel
                {
                    UserId = 2,
                    UserName="Admin",
                    
                },
                new UserModel
                {
                    UserId=1,
                    UserName="Fedor"
                }
            });
        }

    }
}
