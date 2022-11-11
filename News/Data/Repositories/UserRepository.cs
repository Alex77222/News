using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using News.Data.Entities;
using News.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace News.Data.Repositories
{
    public class UserRepository : BaseRepository<User>
    {
        public UserRepository(IConfiguration configuration) : base(configuration)
        { }
   

        protected override string GetQueryForInsert(User entity, string queryRaw)
        {
            return string.Format(queryRaw, entity.Name, entity.Password);
        }

        protected override string GetQueryForUpdate(User entity, string queryRaw)
        {
            return String.Empty;
        }

        protected override IList<User> ReadDataAsync(SqlDataReader reader)
        {
            var userResponses = new List<UserResponse>();
            while (reader.Read())
            {
                userResponses.Add(new UserResponse
                {
                    Id = Convert.ToInt32((reader["UserId"].ToString() ?? string.Empty)),
                    UserName = reader["UserName"].ToString() ?? string.Empty,
                    Password = reader["Password"].ToString() ?? string.Empty,
                    RoleName = reader["RoleName"].ToString() ?? string.Empty,
                });

            }
            return GetUsers(userResponses);
        }
        private IList<User> GetUsers(IList<UserResponse> userResponses)
        {
            var users = new List<User>();

            foreach (var userResponse in userResponses)
            {
                if (users.Any(x => x.Id == userResponse.Id))
                {
                    continue;
                }

                users.Add(new User
                {
                    Id = userResponse.Id,
                    Name = userResponse.UserName,
                    Password = userResponse.Password,
                    Roles = userResponses.Where(x => x.Id == userResponse.Id).Select(x => x.RoleName).ToList(),
                });
            }

            return users;
        }
    }
}