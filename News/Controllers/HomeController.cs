using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using News.Models;
using News.Business.Services;
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
    }
}
