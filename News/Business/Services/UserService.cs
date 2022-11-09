using AutoMapper;
using Microsoft.Extensions.Configuration;
using News.Business.Services.Interfaces;
using News.Data;
using News.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace News.Business.Services
{
    public class UserService : IUserService
    {
        private readonly IConfiguration _configuration;
        private readonly UnitOfWork _db;
        private readonly IMapper _mapper;
        public UserService(IConfiguration configuration, UnitOfWork unitOfWork, IMapper mapper)
        {
            _configuration = configuration;  
            _db = unitOfWork;
            _mapper = mapper;
        }

        public async Task DeleteUserListAsync(int id)
        {
            await _db.Users.DeleteAsync(id);
        }

        public async Task<IList<UserViewModel>> GetListUserAsync()
        {
            var users = await _db.Users.GetListAsync();
            return _mapper.Map<List<UserViewModel>>(users);
        }
    }
}
