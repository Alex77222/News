using Microsoft.AspNetCore.Mvc;
using News.Business.Services.Interfaces;
using System.Threading.Tasks;

namespace News.Controllers
{
    public class SearchController : Controller
    {
        private readonly ISearchService _searchService;
        public SearchController(ISearchService searchService)
        {
            _searchService = searchService;
        }
        [HttpGet]
        public async Task<IActionResult> Search(string searchParameter)
        {
            return View(await _searchService.SearchAsync(searchParameter));
        }
    }
}
