using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using News.Data.Entities;
using News.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace News.Data.Repositories
{
    public class ArticleRepository : BaseRepository<Article>
    {
        public ArticleRepository(IConfiguration configuration) : base(configuration)
        { }
        protected override string GetQueryForInsert(Article entity, string queryRaw)
        {
           return string.Format(queryRaw, entity.Header, entity.Id.ToString(), entity.Body);
        }

        protected override string GetQueryForUpdate(Article entity, string queryRaw)
        {
            return string.Format(queryRaw, entity.Header, entity.Id, entity.Body);
        }

        protected override IList<Article> ReadDataAsync(SqlDataReader reader)
        {
            var artilce = new List<Article>();
            while (reader.Read())
            {
                artilce.Add(new Article
                {
                    Id = Convert.ToInt32((reader["Id"].ToString() ?? string.Empty)),
                    Header = reader["Header"].ToString() ?? string.Empty,
                    Body = reader["Body"].ToString() ?? string.Empty,
                });

            }
            return artilce;
        }
    }
}