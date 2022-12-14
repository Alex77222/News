using News.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace News.Business.Services.Interfaces
{
    public interface IArticleService
    {
        public Task<IList<SmallArticleViewModel>> GetArticlesAsync();
        public Task<ArticleViewModel> GetArticleByIdAsync(int id);
        public Task<IList<SmallArticleViewModel>> GetArticleByUserName(string userName);
        public Task UpdateArticle(ArticleViewModel model);
        public Task DeleteArticleByIdAsync(int id);
        public Task AddArticleAsync(ArticleViewModel model);
    }
}
