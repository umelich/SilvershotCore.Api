using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authentication.OAuth;
using Microsoft.Extensions.Configuration;
using System.IdentityModel.Tokens;
using System.Text;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using SilvershotCore.Models;

namespace SilvershotCore.Controllers
{
    public class LoginController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public LoginController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        [Route("UserLogin")]
        public IActionResult Login(string login, string password)
        {
            UserModel userModel = new UserModel();
            userModel.UserLogin = login;
            userModel.UserPassword = password;

            IActionResult response = Unauthorized();
            var user = AutenticateUser(userModel);
            if (user != null)
            {
                var tokenstring = GenerateWebToken(user);
                user.UserToken = tokenstring;
                response = Ok(new { UserModel = user });
            }
            return response;
        }

        public UserModel AutenticateUser(UserModel userModel)
        {
            UserModel User = null;
            if (userModel.UserLogin == "admin" && userModel.UserPassword == "12345")
            {
                User = new UserModel { UserLogin = userModel.UserLogin, UserPassword = userModel.UserPassword };
            }
            return User;
        }
        private string GenerateWebToken(UserModel userModel)
        {
            var securityKey = AuthOptions.GetSymmetricSecurityKey();
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, userModel.UserLogin),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var jwt = new JwtSecurityToken(
            issuer: AuthOptions.ISSUER,
            audience: AuthOptions.AUDIENCE,
            claims: claims,
            expires: DateTime.UtcNow.Add(TimeSpan.FromSeconds(2)), //lifetime of token = 5 minutes + expires
            signingCredentials: credentials
            );

            var encodedtoken = new JwtSecurityTokenHandler().WriteToken(jwt);

            return encodedtoken;
        }
    }
}
