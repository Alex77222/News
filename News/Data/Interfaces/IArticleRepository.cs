using News.Data.Entities;
using News.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace News.Data.Interfaces
{
    public interface IArticleRepository
    {
        public Task<IList<Article>> GetListAsync();
        public Task<Article> GetListByIdAsync(int Id);
        public Task<IList<Article>> UpdateArticleAsync(Article model);
        public Task DeleteListByIdAsync(int Id);
        public Task<IList<Article>> AddArticleAsync(Article model);
    }
}
