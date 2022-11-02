using Azure.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using News.Business.Services.Interfaces;
using News.Data;
using News.Data.Entities;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Authentication;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace News.Business.Services
{
    public class AuthService : IAuthService
    {
        private readonly IConfiguration _configuration;
        private readonly UnitOfWork _db;
        public AuthService(IConfiguration configuration, UnitOfWork unitOfWork)
        {
            _configuration = configuration;
            _db = unitOfWork;
        }

        public async Task<string> LoginAsync(string userName, string password)
        {
            var user = await _db.Users.GetSingleAsync(userName);
            if (user == null || !user.Password.Equals(GetHash(password)))
            {
                throw new AuthenticationFailedException("Incorrect user name or password");
            }
            return GetJwtToken(user);
        }

        public async Task RegistrationUserAsync(string userName, string password)
        {
            var existingUser = await _db.Users.GetSingleAsync(userName);
            if (existingUser != null)
            {
                throw new AuthenticationException("User already exists");
            }
            var user = new User
            {
                Name = userName,
                Password = GetHash(password),
            };

            await _db.Users.AddAsync(user);


            var userId = (await _db.Users.GetSingleAsync(user.Name)).Id;
            var role = await _db.Roles.GetSingleAsync("user");

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
        private string GetJwtToken(User user)
        {
            var authClaims = new List<Claim>
            {
                new (ClaimTypes.Name, user.Name),
                new (JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            };

            foreach (var userRole in user.Roles!)
            {
                authClaims.Add(new Claim(ClaimTypes.Role, userRole));
            }

            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

            var token = new JwtSecurityToken(
                issuer: _configuration["JWT:ValidIssuer"],
                audience: _configuration["JWT:ValidAudience"],
                expires: DateTime.Now.AddDays(30),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private static string GetHash(string text)
        {
            using var sha256 = SHA256.Create();
            var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(text));
            return BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
        }

    }


}
