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
            throw new System.NotImplementedException();
        }

        protected override string GetQueryForUpdate(Article entity, string queryRaw)
        {
            return string.Format(queryRaw, entity.Name, entity.Id, entity.Body);
        }

        protected override IList<Article> ReadDataAsync(SqlDataReader reader)
        {
            var artilce = new List<ArticleReader>();
            while (reader.Read())
            {
                artilce.Add(new ArticleReader
                {
                    ArticleId = Convert.ToInt32((reader["ArticleId"].ToString() ?? string.Empty)),
                    ArticleHeader = reader["ArticleHeader"].ToString() ?? string.Empty,
                    ArticleBody = reader["ArticleBody"].ToString() ?? string.Empty,
                });

            }
            return GetArticles(artilce);
        }

        private IList<Article> GetArticles(IList<ArticleReader> articleReaders)
        {
            var articles = articleReaders.GroupBy(x => x.ArticleId).Select(GetArticle).ToList(); // ошибка в Seletc пока пытаюсь решить
            return articles;
        }
        private Article GetArticle(IList<ArticleReader> articleReaders)
        {
            var articles = new Article
            {
                Id = articleReaders.First().ArticleId,
                Name = articleReaders.First().ArticleHeader,
                Body = articleReaders.First().ArticleBody,
            };
            return articles;

        }
    }
}