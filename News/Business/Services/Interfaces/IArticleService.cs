using News.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace News.Business.Services.Interfaces
{
    public interface IArticleService
    {
        public Task<IList<ArticleViewModel>> GetArticlesAsync();
        public Task<ArticleViewModel> GetArticleByIdAsync(int Id); 
        public Task<IList<ArticleViewModel>> UpdateArticle(ArticleViewModel model);
        public Task DeleteArticleByIdAsync(int Id);
        public Task<IList<ArticleViewModel>> AddArticleAsync(ArticleViewModel model);
    }
}
