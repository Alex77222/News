using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using News.Data.Entities;
using News.Data.Interfaces;
using System.Collections.Generic;

namespace News.Data.Repositories
{
    public class ArticleRepository : BaseRepository<Article>
    {
        public ArticleRepository(IConfiguration configuration):base(configuration)
            { }
        protected override string GetQueryForInsert(Article entity, string queryRaw)
        {
            throw new System.NotImplementedException();
        }

        protected override string GetQueryForUpdate(Article entity, string queryRaw)
        {
            throw new System.NotImplementedException();
        }

        protected override IList<Article> ReadDataAsync(SqlDataReader reader)
        {
            throw new System.NotImplementedException();
        }
    }
