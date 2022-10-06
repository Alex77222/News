using Microsoft.AspNetCore.Mvc;
using News.Business.Services.Interfaces;
using System.Threading.Tasks;

namespace News.Controllers
{
    public class AdminController : Controller
    {
        private readonly IArticleService _aricleService;
        public AdminController(IArticleService article)
        {
            _aricleService = article;
        }
        public async Task<IActionResult> Admin()
        {
            return View(await _aricleService.GetArticlesAsync());
        }
        public async Task<IActionResult> Edit(int Id)
        {
            return View(await _aricleService.GetArticleByIdAsync(Id));
        }
    }
}
