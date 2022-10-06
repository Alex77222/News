using Microsoft.AspNetCore.Mvc;
using News.Business.Services.Interfaces;
using System.Threading.Tasks;

namespace News.Controllers
{
    public class HomeController : Controller
    {
        private readonly IArticleService _aricleService;
        public HomeController(IArticleService article)
        {
            _aricleService = article;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _aricleService.GetArticlesAsync());
        }

        public async Task<IActionResult> Article(int Id)
        {
            return View(await _aricleService.GetArticleByIdAsync(Id));
        }

    }

}

