using AutoMapper;
using News.Models;
using News.Data.Entities;

namespace News.Business.Mapper.Profiles
{
    public class ArticleProfile : Profile
    {
        public ArticleProfile()
        {
            CreateMap<New,ArticleModel>()
                .ForMember(memberOption  opt
                )
                

    }
}
