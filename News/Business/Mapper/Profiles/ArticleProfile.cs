using AutoMapper;
using News.Models;

namespace News.Business.Mapper.Profiles
{
    public class ArticleProfile : Profile
    {
        public ArticleProfile()
        {
            CreateMap<Article,ArticleModel>()
                .ForMember(
                destinationMember dest:ArticleModel=>
                )
        }

    }
}
