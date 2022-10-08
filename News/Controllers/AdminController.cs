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
        public async Task<IActionResult> Edit(int Id)
        {
            return View(await _aricleService.GetArticleByIdAsync(Id));
        }
        [HttpPost]
        public async Task<IActionResult> Edit(ArticleModel model)
        {
            await _aricleService.UpdateArticle(model);
            return RedirectToAction("Admin", await _aricleService.UpdateArticle(model));
        }
    }
}
