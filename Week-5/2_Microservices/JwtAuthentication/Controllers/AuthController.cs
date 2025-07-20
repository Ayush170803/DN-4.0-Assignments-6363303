using JwtAuthentication.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace JwtAuthentication.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController:ControllerBase
    {
        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginModel model)
        {
            if (model.Username=="admin" && model.Password=="password")
            {
                var token=GenerateJwtToken(model.Username);
                return Ok(new {Token=token});
            }
            return Unauthorized();
        }

        private string GenerateJwtToken(string username)
        {
            var claims=new[]
            {
                new Claim(ClaimTypes.Name,username),
                new Claim(ClaimTypes.Role,"Admin") 
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("ThisIsASuperSecureJwtKeyThatIsLong1234"));
            var creds = new SigningCredentials(key,SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer:"MyAuthServer",
                audience:"MyApiUsers",
                claims:claims,
                expires:DateTime.Now.AddMinutes(60),
                signingCredentials: creds);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
