using News.Data.Entities;
using News.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace News.Business.Services.Interfaces
{
    public interface IArticleService
    {
        public Task<IList<ArticleModel>> GetArticlesAsync();
        public Task<ArticleModel> GetArticleByIdAsync(int Id); 
        public Task<IList<ArticleModel>> UpdateArticle(ArticleModel model);
        public Task DeleteArticleByIdAsync(int Id);
    }
}
