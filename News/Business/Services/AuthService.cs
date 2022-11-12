using Azure.Identity;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
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
        private readonly IRoleService _roleService;

        public AuthService(IConfiguration configuration, UnitOfWork unitOfWork,IRoleService roleService)
        {
            _configuration = configuration;
            _db = unitOfWork;
            _roleService = roleService;
        }

        public async Task<ClaimsIdentity> LoginAsync(string userName, string password)
        {
            var user = await _db.Users.GetSingleAsync(userName);
            if (user == null || !user.Password.Equals(GetHash(password)))
            {
                throw new AuthenticationFailedException("Incorrect user name or password");
            }
            return GetClaimsIdentity(user);
        }

        public async Task RegisterUserAsync(string userName, string password)
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
            await _roleService.AssignRoleByUserAsync(user.Name, "User");
        }

        private ClaimsIdentity GetClaimsIdentity(User user)
        {
      
            var authClaims = new List<Claim>
            {
                new (ClaimTypes.Name, user.Name),
            };

            foreach (var userRole in user.Roles!)
            {
                authClaims.Add(new Claim(ClaimTypes.Role, userRole));
            }

            return new ClaimsIdentity(authClaims, "SystemNewsCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
            
        }

        private static string GetHash(string text)
        {
            using var sha256 = SHA256.Create();
            var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(text));
            return BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
        }

    }


}
