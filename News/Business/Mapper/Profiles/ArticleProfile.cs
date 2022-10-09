using AutoMapper;
using News.Data.Entities;
using News.Models;

namespace News.Business.Mapper.Profiles
{
    public class ArticleProfile : Profile
    {
        public ArticleProfile()
        {
            CreateMap<Article, ArticleViewModel>()
                .ForMember(dest => dest.NewsId, opt => opt.MapFrom(x => x.Id))
                .ForMember(dest => dest.NewsHeader, opt => opt.MapFrom(x => x.Name))
                .ForMember(dest => dest.NewsText, opt => opt.MapFrom(x => x.Body));
        }
    }
}
