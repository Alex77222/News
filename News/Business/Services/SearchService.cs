using AutoMapper;
using News.Business.Services.Interfaces;
using News.Data;
using News.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace News.Business.Services
{
    public class SearchService : ISearchService
    {
        private readonly UnitOfWork _db;
        private readonly IMapper _mapper;
        public SearchService(UnitOfWork unitOfWork, IMapper mapper)
        {
            _db = unitOfWork;
            _mapper = mapper;
        }
        public async Task<IList<SmallArticleViewModel>> SearchAsync(string searchParameter)
        {

            return  _mapper.Map<List<SmallArticleViewModel>>(await _db.Articles.SearchAsync(searchParameter));
        }
    }
}
