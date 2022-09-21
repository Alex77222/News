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
            return View(
            
                new NewsModel
                {
                    NewsId =1,
                    NewsHeader = " TCP/IP",
                    NewsText = "Что такое TCP/IPПроизошло наименование протокола от сокращения двух английских понятий – Transmission Control Protocol и Internet Protocol.Набор правил, входящий в него, позволяет обрабатывать как сквозную передачу данных,так и другие детали этого механизма.Сюда входит формирование пакетов,способ их отправки получения, маршрутизации, распаковки для передачи программному обеспечению."
                }
            );
        }
    }
}
