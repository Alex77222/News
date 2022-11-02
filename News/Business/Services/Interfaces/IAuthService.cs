using System.Threading.Tasks;

namespace News.Business.Services.Interfaces
{
    public interface IAuthService
    {
        public Task RegistrationUserAsync(string userName, string password);
        public Task<string> LoginAsync(string userName, string password);

    }
}
