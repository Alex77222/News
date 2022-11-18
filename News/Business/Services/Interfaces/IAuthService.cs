using System.Security.Claims;
using System.Threading.Tasks;

namespace News.Business.Services.Interfaces
{
    public interface IAuthService
    {
        public Task RegisterUserAsync(string userName, string password);
        public Task<ClaimsIdentity> LoginAsync(string userName, string password);

    }
}
