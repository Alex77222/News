using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using News.Data.Entities;
using System.Collections.Generic;

namespace News.Data.Repositories
{
    public class UserRolesRepository : BaseRepository<UserRoles>
    {
        public UserRolesRepository(IConfiguration configuration) : base(configuration)
        {

        }
        protected override string GetQueryForDelete(object parameters, string queryRaw)
        {
            var userId = parameters.GetType().GetProperty("UserId").GetValue(parameters, null);
            var roleId = parameters.GetType().GetProperty("RoleId").GetValue(parameters, null);
            return string.Format(queryRaw, userId, roleId);
        }
        protected override IList<UserRoles> ReadDataAsync(SqlDataReader reader)
        {
            return new List<UserRoles>();
        }
        protected override string GetQueryForInsert(UserRoles entity, string queryRaw)
        {
            return string.Format(queryRaw, entity.UserId, entity.RoleId);
        }
        protected override string GetQueryForUpdate(UserRoles entity, string queryRaw)
        {
            return string.Empty;
        }
    }
}
