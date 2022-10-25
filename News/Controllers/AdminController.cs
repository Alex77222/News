using Microsoft.AspNetCore.Mvc;
using News.Business.Services.Interfaces;
using News.Models;
using System.Threading.Tasks;

namespace News.Controllers
{
    public class AdminController : Controller
    {
        private readonly IArticleService _articleService;
        public AdminController(IArticleService articleservice)
        {
            _articleService = articleservice;
        }

        public async Task<IActionResult> Admin()
        {
            return View(await _articleService.GetArticlesAsync());
        }

        public async Task<IActionResult> DeleteAsync(int id)
        {
            await _articleService.DeleteArticleByIdAsync(id);
            return RedirectToAction("Admin");
        }
        public async Task<IActionResult> Edit(int id)
        {
            return View(await _articleService.GetArticleByIdAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> EditAsync(ArticleViewModel model)
        {
            
            await _articleService.UpdateArticle(model);
            return RedirectToAction("Admin");
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync(ArticleViewModel model)
        {
            await _articleService.AddArticleAsync(model);
            return RedirectToAction("Admin");
        }
    }
}
