using System.Collections.Generic;
using System.Threading.Tasks;

namespace News.Business.Services.Interfaces
{
    public interface IRoleService
    {
        public Task RemoveRoleAsync(string userName);
        public Task AssignRoleByUserAsync(string userName,string role); 
        public Task<IList<string>> GetListRoleAsync();
    }
}
