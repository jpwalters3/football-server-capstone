using FootballServerCapstone.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Net.Http;
using System.Text;

namespace FootballServerCapstone.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        [HttpPost]
        [Route("login")]
        public IActionResult Login(LoginModel user)
        {
            if (user == null)
            {
                return BadRequest("Invalid request");
            }

            if (user.UserName == "admin" && user.Password == "adminPassword!")
            {
                var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("KeyForSignInSecret@1234"));
                var signInCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

                var tokenOptions = new JwtSecurityToken(
                    issuer: "http://localhost:2000",
                    audience: "http://localhost:2000",
                    claims: new List<Claim>(),
                    expires: DateTime.Now.AddDays(3),       //change back to 30 minutes after web testing
                    signingCredentials: signInCredentials
                    );
                var tokenString = new JwtSecurityTokenHandler().WriteToken(tokenOptions);
                return Ok(new { Token = tokenString });
            }
            else
            {
                return Unauthorized();
            }
        }
    }
}
