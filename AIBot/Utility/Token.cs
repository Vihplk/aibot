using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AIBot.Core.Dto.Security;
using Microsoft.IdentityModel.Tokens;
using IConfiguration = Microsoft.Extensions.Configuration.IConfiguration;
using AIBot.Core;

namespace AIBot.Utility
{
    public class Token
    {
        private readonly IConfiguration _configuration;
        public Token(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public string JwtTokenBuilder(LoginResponseDto request)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8
                .GetBytes(GlobalConfig.Key));

            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var jwtToken = new JwtSecurityToken(issuer: GlobalConfig.Issuer,
                audience: GlobalConfig.Audience, signingCredentials: credentials,
                expires: DateTime.Now.AddMinutes(10),
                claims: new List<Claim>()
                {
                    new Claim("email", request.Email),
                    new Claim("userid", request.Id.ToString()),
                    new Claim("name", request.Name)
                }
            );
            return new JwtSecurityTokenHandler().WriteToken(jwtToken);
        }
    }
}
