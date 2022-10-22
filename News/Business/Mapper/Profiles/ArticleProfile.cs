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
                .ForMember(dest => dest.NewsHeader, opt => opt.MapFrom(x => x.Header))
                .ForMember(dest => dest.NewsText, opt => opt.MapFrom(x => x.Body));
            CreateMap<ArticleViewModel, Article>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(x => x.NewsId))
                .ForMember(dest => dest.Header, opt => opt.MapFrom(x => x.NewsHeader))
                .ForMember(dest => dest.Body, opt => opt.MapFrom(x => x.NewsText));
        }
    }
}
