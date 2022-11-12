using System.Linq;
using System.Security.Claims;

namespace News.Helpers
{
    public static class AuthorizeHelper
    {
        public static bool ContainsRoles(ClaimsPrincipal user, params string[] roles)
        {
            foreach (var role in roles)
            {
                if (user.Claims.Where(x => x.Type.Contains("claims/role")).Select(x => x.Value).Contains(role))
                {
                    return true;
                } 
            }
            return false;
        }
    }
}
