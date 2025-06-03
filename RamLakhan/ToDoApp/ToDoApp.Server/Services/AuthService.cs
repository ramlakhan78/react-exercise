using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using ToDoApp.Server.Contracts;
using ToDoApp.Server.Models;

namespace ToDoApp.Server.Services
{
    public class AuthService(IConfiguration configuration, IHttpContextAccessor httpContextAccessor) : IAuthService
    {
        public ResponseModel AuthenticateAsync(LoginRequestModel model)
        {
            var httpContext = httpContextAccessor.HttpContext;
            if (httpContext == null) return new() { IsSuccess = false, Message = "Request is null, please try again later!" };

            var accessToken = GenerateJwtToken(model.Username);

            return new() { IsSuccess = true, Message = "User Authenticated!", Data = new { accessToken } };
        }

        public Task<bool> RegisterAsync(string username, string password)
        {
            throw new NotImplementedException();
        }

        private string GenerateJwtToken(string username)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(configuration["Jwt:Key"]);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] {
                new Claim(ClaimTypes.Name, username)
                  }),
                Expires = DateTime.UtcNow.AddHours(1),
                Issuer = configuration["Jwt:Issuer"],
                Audience = configuration["Jwt:Audience"],
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
