using Microsoft.AspNetCore.Mvc;
using News.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace News.Controllers
{
    public class NewsController : Controller
    {
        public IActionResult News()
        {
            return View(new List<NewsModel>
            {
                new NewsModel
                {
                    NewsID =1,
                    NewsHeadr = " TCP/IP",
                    NewsText = "Какойто текст про TCp/IPКакойто текст про TCp/IPКакойто текст про TCp/IPКакойто текст про TCp/IPКакойто текст про TCp/IPКакойто текст про TCp/IPКакойто текст про TCp/IPКакойто текст про TCp/IP"
                },
                 new NewsModel
        {
                     NewsID=2,
                    NewsHeadr = "Soft",
                    NewsText = " Какойто текст про Soft Какойто текст про Soft Какойто текст про Soft Какойто текст про Soft Какойто текст про Soft Какойто текст про Soft Какойто текст про Soft "
                }
            });
        }
    }
}
