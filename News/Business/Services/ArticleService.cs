using AutoMapper;
using News.Business.Services.Interfaces;
using News.Data.Entities;
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
        public async Task<IList<ArticleModel>> GetArticlesAsync()
        {
            var articles =  await _articleRepository.GetListAsync();
            return _mapper.Map<List<ArticleModel>>(articles);

        }
        public async Task<ArticleModel> GetArticleByIdAsync(int Id)
        {
            var article = await _articleRepository.GetListByIdAsync(Id);
            
            return _mapper.Map<ArticleModel>(article);

        }
    }
}
