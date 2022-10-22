using AutoMapper;
using News.Business.Services.Interfaces;
using News.Data.Entities;
using News.Data.Interfaces;
using News.Data.Repositories;
using News.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace News.Business.Services
{
    public class ArticleService : IArticleService
    {
        private readonly ArticleRepository _articleRepository;
        private readonly IMapper _mapper;
        public ArticleService(ArticleRepository articleRepository, IMapper mapper)
        {
            _articleRepository = articleRepository;
            _mapper = mapper;
        }
        public async Task<IList<ArticleViewModel>> GetArticlesAsync()
        {
            var articles = await _articleRepository.GetListAsync();
            return _mapper.Map<List<ArticleViewModel>>(articles);

        }
        public async Task<ArticleViewModel> GetArticleByIdAsync(int Id)
        {
            var article = await _articleRepository.GetByIdAsync(Id);

            return _mapper.Map<ArticleViewModel>(article);

        }

        public async Task<IList<ArticleViewModel>> UpdateArticle(Article model)
        {
            var articles = await _articleRepository.UpdateAsync(model);
            return _mapper.Map<List<ArticleViewModel>>(articles);
        }
        public async Task DeleteArticleByIdAsync(int Id)
        {
            await _articleRepository.DeleteAsync(Id);

        }
        public async Task<IList<ArticleViewModel>> AddArticleAsync(Article model)
        {
            var articles = await _articleRepository.AddAsync(model);
            return _mapper.Map<List<ArticleViewModel>>(articles);

        }


    }
}
