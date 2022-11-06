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

        public async Task AssignRoleByUserAsync(string userName, string roleName)
        {
            var userId = (await _db.Users.GetSingleAsync(userName)).Id;
            var role = await _db.Roles.GetSingleAsync(roleName);

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

        public Task RemoveRoleAsync(string userName)
        {
            throw new System.NotImplementedException();
        }

        public Task<IList<string>> GetListRoleAsync()
        {
            throw new System.NotImplementedException();
        }
    }
}
