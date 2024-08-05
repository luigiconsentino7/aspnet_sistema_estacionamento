using Domain.Account;
using Domain.Entities;
using Infrastructure.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Identity
{
    public class Autheticate(AppDbContext appDbContext, IConfiguration configuration) : IAuthenticate
    {
        private readonly AppDbContext _appDbContext = appDbContext;
        private readonly IConfiguration _configuration = configuration;


        public bool Authenticate(string email, string password)
        {
            var user = _appDbContext.Users.Where(x => x.Email.ToLower() == email.ToLower()).FirstOrDefault();
            if (user == null)
            {
                return false;
            }
            else
            {
                using var hmac = new HMACSHA512(user.PasswordSalt);
                var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                for(int x = 0; x < computedHash.Length; x++)
                {
                    if (computedHash[x] != user.PasswordHash[x])
                    {
                        return false;
                    }
                }

                return true;
            }
        }

        public string GenerateToken(int id, string email)
        {
            var claims = new[] 
            {
                new Claim("id", id.ToString()),
                new Claim("email", email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var privateKey = new SymmetricSecurityKey(Encoding.UTF8
                .GetBytes(_configuration["jwt:secretKey"]));

            var credentials = new SigningCredentials(privateKey, SecurityAlgorithms.HmacSha256);

            var expiration = DateTime.UtcNow.AddMinutes(10);

            JwtSecurityToken token = new JwtSecurityToken(
                issuer: _configuration["jwt:issuer"],
                audience: _configuration["jwt:audience"],
                claims: claims,
                expires: expiration,
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public bool UserExist(string email)
        {
            var user = _appDbContext.Users.Where(x => x.Email.ToLower() == email.ToLower()).FirstOrDefault();
            if (user == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }


    }
}
