using Microsoft.AspNetCore.Mvc;
using News.Business.Services.Interfaces;
using System.Threading.Tasks;

namespace News.Controllers
{
    public class HomeController : Controller
    {
        private readonly IArticleService _aricleService;
        public HomeController(IArticleService articleService)
        {
            _aricleService = articleService;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _aricleService.GetArticlesAsync());
        }

        public async Task<IActionResult> Article(int id)
        {
            return View(await _aricleService.GetArticleByIdAsync(id));
        }

    }

}

