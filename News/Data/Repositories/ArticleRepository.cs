using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using News.Data.Entities;
using System;
using System.Collections.Generic;

namespace News.Data.Repositories
{
    public class ArticleRepository : BaseRepository<Article>
    {
        public ArticleRepository(IConfiguration configuration) : base(configuration)
        { }


        protected override string GetQueryForInsert(Article entity, string queryRaw)
        {
            return string.Format(queryRaw, entity.Header, entity.Body, entity.UserId);
        }

        protected override string GetQueryForUpdate(Article entity, string queryRaw)
        {
            return string.Format(queryRaw, entity.Header, entity.Body, entity.Id);
        }

        protected override IList<Article> ReadDataAsync(SqlDataReader reader)
        {
            var artilce = new List<Article>();
            while (reader.Read())
            {
                artilce.Add(new Article
                {
                    Id = Convert.ToInt32((reader["ArticleId"].ToString() ?? string.Empty)),
                    Header = reader["Header"].ToString() ?? string.Empty,
                    Body = reader["Body"].ToString() ?? string.Empty,
                    UserId = Convert.ToInt32((reader["UserId"].ToString() ?? string.Empty)),
                    User = new User 
                    {
                        Id = Convert.ToInt32((reader["UserId"].ToString() ?? string.Empty)),    
                        Name = reader["UserName"].ToString() ?? string.Empty,    
                    }
                });

            }
            return artilce;
        }
    }
}