using News.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace News.Business.Services.Interfaces
{
    public interface ISearchService
    {
        public Task<IList<SmallArticleViewModel>> SearchAsync(string searchParameter); 
    }
}
