using News.Data.Entities;
using News.Models;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace News.Business.Services.Interfaces
{
    public interface IUserService
    {
       public Task<IList<UserViewModel>> GetListUserAsync();
       public Task DeleteUserListAsync(int id);
       public Task<IList<UserViewModel>> GetUserByIdAsync(int id);
    }
}
