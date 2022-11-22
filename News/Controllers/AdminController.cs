using Microsoft.AspNetCore.Mvc;
using News.Business.Services.Interfaces;
using News.Helpers;
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
            if (AuthorizeHelper.ContainsRoles(User, "Admin"))
            {
                return View(await _articleService.GetArticlesAsync());
            }
            else if (AuthorizeHelper.ContainsRoles(User, "Moderator"))
            {
                return View(await _articleService.GetArticleByUserName(User.Identity.Name));
            }
            return View();
           
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
            if (!AuthorizeHelper.ContainsRoles(User, "Admin", "Moderator"))
            {
                return BadRequest();

            }
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
            if (!AuthorizeHelper.ContainsRoles(User,"Admin", "Moderator"))
            {
                return BadRequest();
                
            }
            await _articleService.AddArticleAsync(model);
            return RedirectToAction("Admin");

        }
    }
}
