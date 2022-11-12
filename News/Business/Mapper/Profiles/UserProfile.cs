using AutoMapper;
using News.Data.Entities;
using News.Models;

namespace News.Business.Mapper.Profiles
{
    public class UserProfile: Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserViewModel>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(x => x.Id))
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(x => x.Name))
                .ForMember(dest => dest.Roles, opt => opt.MapFrom(x => x.Roles));
            CreateMap<UserViewModel, User>()
               .ForMember(dest => dest.Id, opt => opt.MapFrom(x => x.Id))
               .ForMember(dest => dest.Name, opt => opt.MapFrom(x => x.UserName))
               .ForMember(dest => dest.Roles, opt => opt.MapFrom(x => x.Roles));
        }
    }
}
