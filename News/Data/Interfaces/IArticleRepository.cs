using News.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace News.Data.Interfaces
{
    public interface IArticleRepository
    {
        public Task<IList<Article>> GetListAsync();
        public Task<Article> GetListByIdAsyncc(int Id);
    }
}
