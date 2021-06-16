using IdentityLibrary.API_Requests;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.API.Extensions
{
    public class TokenDtoHelper
    {
        private readonly IConfiguration _config;

        public TokenDtoHelper(IConfiguration config)
        {
            this._config = config;
        }

        public TokenDto Helper(string userEmail)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_config.GetValue<string>("TokenKey"));
            var tokenDescriptior = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, userEmail)
                }),
                    IssuedAt = DateTime.UtcNow,
                    Expires = DateTime.UtcNow.AddDays(1),
                    SigningCredentials = 
                    new SigningCredentials(new SymmetricSecurityKey(key),
                        SecurityAlgorithms.HmacSha256Signature)
            };

            var timeSpan = (DateTime)tokenDescriptior.Expires - (DateTime)tokenDescriptior.IssuedAt;
            var secondTimeSpan = (int)timeSpan.TotalSeconds;

            var formattedIssuedAt = (DateTime)tokenDescriptior.IssuedAt;
            var formattedExpires = (DateTime)tokenDescriptior.Expires;

            var token = tokenHandler.CreateToken(tokenDescriptior);

            var tokenDto = new TokenDto
            {
                AccessToken = tokenHandler.WriteToken(token),
                TokenType = JwtBearerDefaults.AuthenticationScheme.ToLower(),
                ExpiresIn = secondTimeSpan,
                Username = userEmail,
                TokenIssued = formattedIssuedAt.ToString("ddd, dd MMM yyy HH':'mm':'ss 'UTC'"),
                TokenExpires = formattedExpires.ToString("ddd, dd MMM yyy HH':'mm':'ss 'UTC'"),
            };

            return tokenDto;
        }
    }
}
