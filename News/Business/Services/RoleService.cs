using Microsoft.Extensions.Configuration;
using News.Business.Services.Interfaces;
using News.Data;
using News.Data.Entities;
using System.Collections.Generic;
using System.Data;
using System.Linq;
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

       public async Task RemoveRoleAsync(string userName,string roleName)
        {
            var userId = (await _db.Users.GetSingleAsync(userName)).Id;
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

        public async Task UpdateRoleAsync(string userName, List<string> comingRoles)
        {
            var userRoles= (await _db.Users. GetSingleAsync(userName)).Roles;
            foreach (var role in userRoles)
            {
                if (!comingRoles.Contains(role))
                {
                    await RemoveRoleAsync(userName, role);
                }
            }
            userRoles.AddRange(comingRoles.Where(comingRoles=>!userRoles.Contains(comingRoles)));
            foreach (var role in comingRoles)
            {
                await AssignRoleByUserAsync(userName, role);
            }
            if (userRoles.Count>=0)
            {
                await AssignRoleByUserAsync(userName, "User");
            }
        }
    }
}
