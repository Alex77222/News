using Microsoft.AspNetCore.Mvc;
using News.Business.Services.Interfaces;
using News.Models;
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

        public async Task<IActionResult> Delete(int Id)
        {
            await _aricleService.DeleteArticleByIdAsync(Id);
            return RedirectToAction("Admin");
        }
        public async Task<IActionResult> Edit(int id)
        {
            return View(await _aricleService.GetArticleByIdAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ArticleViewModel model)
        {
            await _aricleService.UpdateArticle(model);
            return RedirectToAction("Admin", await _aricleService.UpdateArticle(model));
        }

        public  IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(ArticleViewModel model)
        {
            await _aricleService.AddArticleAsync(model);
            return RedirectToAction("Admin", await _aricleService.AddArticleAsync(model));
        }
    }
}
