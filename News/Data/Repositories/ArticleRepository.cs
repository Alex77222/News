using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using News.Data.Entities;
using News.Data.Interfaces;


namespace News.Data.Repositories
{
    public class ArticleRepository:IArticleRepository
    {
        public async Task<IList<Article>> GetListAsync()
        {
           var articles = new List<Article>
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
            return await Task.FromResult(articles); 
        }
    }
}
