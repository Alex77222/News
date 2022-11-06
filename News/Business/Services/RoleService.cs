using Microsoft.Extensions.Configuration;
using News.Business.Services.Interfaces;
using News.Data;
using News.Data.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace News.Business.Services
{
    public class RoleService :IRoleService
    {
        private readonly UnitOfWork _db;
        private readonly IConfiguration _configuration;
        public RoleService(IConfiguration configuration, UnitOfWork unitOfWork)
        {
            _configuration = configuration;
            _db = unitOfWork;
        }

        public async Task AddRoleByUserNameAsync(string userName)
        {
            var userId = (await _db.Users.GetSingleAsync(userName)).Id;
            var role = await _db.Roles.GetSingleAsync("user");

            if (role == null)
            {
                return;
            }
            await _db.UserRoles.AddAsync(new UserRoles
            {
                UserId = userId,
                RoleId = role.Id,
            });
        }

        public Task DeleteRoleAsync(string userName)
        {
            throw new System.NotImplementedException();
        }

        public Task<IList<string>> GetLidtRoleAsync()
        {
            throw new System.NotImplementedException();
        }

        public Task<IList<string>> GetRolesAsync()
        {
            throw new System.NotImplementedException();
        }

        public Task<IList<string>> GetRolesByUserNameAsync(string userName)
        {
            throw new System.NotImplementedException();
        }
    }
}
