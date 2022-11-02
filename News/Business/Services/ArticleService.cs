using AutoMapper;
using News.Business.Services.Interfaces;
using News.Data;
using News.Data.Entities;
using News.Data.Repositories;
using News.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace News.Business.Services
{
    public class ArticleService : IArticleService
    {
        private readonly UnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public ArticleService(UnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<IList<ArticleViewModel>> GetArticlesAsync()
        {

            var articles = await _unitOfWork.Articles.GetListAsync();
            return _mapper.Map<List<ArticleViewModel>>(articles);

        }
        public async Task<ArticleViewModel> GetArticleByIdAsync(int id)
        {
            var article = await _unitOfWork.Articles.GetByIdAsync(id);

            return _mapper.Map<ArticleViewModel>(article);

        }

        public async Task UpdateArticle(ArticleViewModel model)
        {
            var articles = _mapper.Map<Article>(model);
            await _unitOfWork.Articles.UpdateAsync(articles);

        }
        public async Task DeleteArticleByIdAsync(int id)
        {
            await _unitOfWork.Articles.DeleteAsync(id);

        }
        public async Task AddArticleAsync(ArticleViewModel model)
        {
            var articles = _mapper.Map<Article>(model);
            await _unitOfWork.Articles.AddAsync(articles);
        }
    }
}
