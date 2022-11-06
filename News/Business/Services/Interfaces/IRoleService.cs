using System.Collections.Generic;
using System.Threading.Tasks;

namespace News.Business.Services.Interfaces
{
    public interface IRoleService
    {
        public Task DeleteRoleAsync(string userName);
        public Task AddRoleByUserNameAsync(string userName);
        public Task<IList<string>> GetLidtRoleAsync();
        public Task<IList<string>> GetRolesAsync();
        public Task<IList<string>> GetRolesByUserNameAsync(string userName);
    }
}
