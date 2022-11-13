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

        public async Task RemoveRoleAsync(int id,string roleName)
        {
            var user = await _db.Users.GetByIdAsync(id);
            var userId = (await _db.Users.GetSingleAsync(user.Name)).Id;
            var role = await _db.Roles.GetSingleAsync(roleName);

            if (role == null)
            {
                return;
            }
            await _db.UserRoles.DeleteAsync(new UserRoles
            {
                UserId=userId,
                RoleId=role.Id, 
            });
        }

        public async Task<IList<Role>> GetListRoleAsync()
        {
           return( await _db.Roles.GetListAsync());
        }
    }
}
