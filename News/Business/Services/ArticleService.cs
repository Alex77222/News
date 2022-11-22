using AutoMapper;
using News.Business.Services.Interfaces;
using News.Data;
using News.Data.Entities;
using News.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace News.Business.Services
{
    public class ArticleService : IArticleService
    {
        private readonly UnitOfWork _db;
        private readonly IMapper _mapper;
        public ArticleService(UnitOfWork unitOfWork, IMapper mapper)
        {
            _db = unitOfWork;
            _mapper = mapper;
        }
        public async Task<IList<SmallArticleViewModel>> GetArticlesAsync()
        {
            var articles = await _db.Articles.GetListAsync();
            return _mapper.Map<List<SmallArticleViewModel>>(articles);

        }
        public async Task<ArticleViewModel> GetArticleByIdAsync(int id)
        {
            var article = await _db.Articles.GetByIdAsync(id);

            return _mapper.Map<ArticleViewModel>(article);

        }

        public async Task UpdateArticle(ArticleViewModel article)
        {
            var articles = _mapper.Map<Article>(article);
            await _db.Articles.UpdateAsync(articles);

        }
        public async Task DeleteArticleByIdAsync(int id)
        {
            await _db.Articles.DeleteAsync(id);

        }
        public async Task AddArticleAsync(ArticleViewModel article)
        {
            var user = await _db.Users.GetSingleAsync(article.Author);
            var articleEntity = _mapper.Map<Article>(article);
            articleEntity.UserId = user.Id;
            await _db.Articles.AddAsync(articleEntity);
        }

        public async Task<IList<SmallArticleViewModel>> GetArticleByUserName(string userName)
        {
            var userId = (await _db.Users.GetSingleAsync(userName)).Id;
            var articles = await _db.Articles.GetByUserIdAsync(userId);
            return _mapper.Map<List<SmallArticleViewModel>>(articles);

        }
    }
}
