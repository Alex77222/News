using Microsoft.AspNetCore.Mvc;
using News.Business.Services;
using News.Business.Services.Interfaces;
using News.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace News.Controllers
{
    public class ArticleController : Controller
    {
        private readonly IArticleService _aricleService;
        public ArticleController(IArticleService article)
        {
            _aricleService = article;
        }
        public IActionResult Article()
        {
            return View(
            
                new ArticleModel
                {
                    NewsId =1,
                    NewsHeader = " TCP/IP",
                    NewsText = "Что такое TCP/IPПроизошло наименование протокола от сокращения двух английских понятий – Transmission Control Protocol и Internet Protocol.Набор правил, входящий в него, позволяет обрабатывать как сквозную передачу данных,так и другие детали этого механизма.Сюда входит формирование пакетов,способ их отправки получения, маршрутизации, распаковки для передачи программному обеспечению."
                }
            );
        }
        [HttpPost]
        public async Task<IActionResult> Article(int Id)
        {
            
            return View(await _aricleService.GetArticleByIdAsync(Id));
        }
    }
}
