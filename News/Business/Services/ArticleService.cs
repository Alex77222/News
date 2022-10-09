using AutoMapper;
using News.Business.Services.Interfaces;
using News.Data.Interfaces;
using News.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace News.Business.Services
{
    public class ArticleService : IArticleService
    {
        private readonly IArticleRepository _articleRepository;
        private readonly IMapper _mapper;
        public ArticleService(IArticleRepository articleRepository, IMapper mapper)
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
            var article = await _articleRepository.GetListByIdAsync(Id);

            return _mapper.Map<ArticleViewModel>(article);

        }

        public async Task<IList<ArticleViewModel>> UpdateArticle(ArticleViewModel model)
        {
            var articles = await _articleRepository.UpdateArticleAsync(model);
            return _mapper.Map<List<ArticleViewModel>>(articles);
        }
        public async Task DeleteArticleByIdAsync(int Id)
        {
            await _articleRepository.DeleteListByIdAsync(Id);

        }
        public async Task<IList<ArticleViewModel>> AddArticleAsync(ArticleViewModel model)
        {
            var articles = await _articleRepository.AddArticleAsync(model);
            return _mapper.Map<List<ArticleViewModel>>(articles);

        }


    }
}
