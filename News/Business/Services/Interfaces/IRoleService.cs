using News.Data.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace News.Business.Services.Interfaces
{
    public interface IRoleService
    {
        public Task RemoveRoleAsync(string userName,string roleName);
        public Task AssignRoleByUserAsync(string userName,string roleName); 
        public Task<IList<Role>> GetListRoleAsync();
        public Task UpdateRoleAsync(string userName, List<string> comingRoles);
    }
}
