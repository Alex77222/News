using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

using News.Business.Services.Interfaces;

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

            var news = await _aricleService.GetArticleByIdAsync(Id);
            return View(news);
        }
    }

}

