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
                .ForMember(dest => dest.Id, opt => opt.MapFrom(x => x.Id))
                .ForMember(dest => dest.Header, opt => opt.MapFrom(x => x.Header))
                .ForMember(dest => dest.Text, opt => opt.MapFrom(x => x.Body))
                .ForMember(dest => dest.Author, opt => opt.MapFrom(x=>x.User.Name));
            CreateMap<ArticleViewModel, Article>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(x => x.Id))
                .ForMember(dest => dest.Header, opt => opt.MapFrom(x => x.Header))
                .ForMember(dest => dest.Body, opt => opt.MapFrom(x => x.Text))
                .ForMember(dest => dest.UserId, opt => opt.Ignore())
                .ForMember(dest => dest.User, opt => opt.Ignore());
        }
    }
}
