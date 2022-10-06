using News.Data.Entities;
using News.Data.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace News.Data.Repositories
{
    public class ArticleRepository : IArticleRepository
    {
        private List<Article> _articles;

        public ArticleRepository()
        {
            _articles = new List<Article>()
            {
                new Article
                {
                    Id =1,
                    Body = "Text in body lalalalal",
                    Name="Article 1"
                },
                 new Article
                {
                    Id =2,
                    Body = "Text in body 2 lalalgegegegegegalal",
                    Name="Article 2"
                },
                   new Article
                {
                    Id =3,
                    Body = "Text in body 3 lalalgegegpypypyyppegegegalal",
                    Name="Article 3"
                },


            };
        }
        public async Task<IList<Article>> GetListAsync()
        {

            return await Task.FromResult(_articles);
        }

        public async Task<Article> GetListByIdAsync(int Id)
        {
            return await Task.FromResult(_articles.FirstOrDefault(x => x.Id == Id));
        }

        public async Task<IList<Article>> SaveChangesAsync(int Id, string Name, string Body)
        {
            var ar = _articles.FirstOrDefault(x => x.Id == Id);
            ar.Name = Name;
            ar.Body = Body;
            return await Task.FromResult(_articles);
        }
    }
}
