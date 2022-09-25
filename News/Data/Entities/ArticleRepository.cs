using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using News.Data.Interfaces;

namespace News.Data.Entities
{
    public class ArticleRepository:IArticleRepository
    {
        public async Task<IList<New>> GetListAsync()
        {
           var news= new List<New>
            {
                new New
                {
                    Id =1,
                    Body = "Text in body lalalalal",
                    Name="Article 1"
                },
                 new New
                {
                    Id =2,
                    Body = "Text in body 2 lalalgegegegegegalal",
                    Name="Article 2"
                },
                   new New
                {
                    Id =3,
                    Body = "Text in body 3 lalalgegegpypypyyppegegegalal",
                    Name="Article 3"
                },


            };
            return news;
        }
    }
}
