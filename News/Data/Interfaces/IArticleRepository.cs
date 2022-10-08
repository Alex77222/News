using News.Data.Entities;
using News.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace News.Data.Interfaces
{
    public interface IArticleRepository
    {
        public Task<IList<Article>> GetListAsync();
        public Task<Article> GetListByIdAsync(int Id);
        public Task<IList<Article>> SaveChangesAsync(ArticleModel   model);
        public Task DeleteListByIdAsync(int Id);
    }
}
