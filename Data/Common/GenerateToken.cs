using Data.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Data.Common
{
    public static class GenerateToken
    {
        public static string GetToken(LoginModel loginModel, IConfiguration _configuration)
        {
            var Claims = new[]
            {
            new Claim(JwtRegisteredClaimNames.Sub, loginModel.username),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
           // new Claim("IpAddress", loginModel.IpAddress),
           // new Claim("BrowserName", loginModel.BrowserName),
          //  new Claim("BrowserVersion", loginModel.BrowserVersion),
          //  new Claim("MahindraUser", loginModel.mahindraUser.ToString())
        };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                _configuration["Jwt:Issuer"],
                _configuration["Jwt:Audience"],
                Claims,
                expires: DateTime.UtcNow.AddDays(10),
                signingCredentials: signIn);

            var Token = new JwtSecurityTokenHandler().WriteToken(token);
            return Token;
        }
    }
}