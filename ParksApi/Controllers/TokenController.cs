using ParksApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Cors;

namespace ParksApi.Controllers
{
  [Route("api/token")]
  [ApiController]
  public class TokenController : ControllerBase
  {
    public IConfiguration _configuration;
    private readonly ParksApiContext _db;

    public TokenController(IConfiguration config, ParksApiContext db)
    {
      _configuration = config;
      _db = db;
    }
    [EnableCors("Policy")]
    [HttpPost]
    public async Task<IActionResult> Post (UserInfo _userData)
    {
      if (_userData != null && _userData.UserName != null && _userData.Password != null)
      {
        var user = await GetUser(_userData.UserName, _userData.Password);

        if (user != null)
        {
          //create claims details based on the user information
          var claims = new[] {
              new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
              new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
              new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
              new Claim("UserId", user.UserInfoId.ToString()),
              new Claim("DisplayName", user.DisplayName),
              new Claim("UserName", user.UserName),
              new Claim("Email", user.Email)
          };

          var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
          var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
          var token = new JwtSecurityToken(
            _configuration["Jwt:Issuer"],
            _configuration["Jwt:Audience"],
            claims,
            expires: DateTime.UtcNow.AddMinutes(10),
            signingCredentials: signIn);

            return Ok(new JwtSecurityTokenHandler().WriteToken(token));
        }
        else
        {
          return BadRequest("Invalid credentials");
        }
      }
      else
      {
        return BadRequest();
      }
    }

    private async Task<UserInfo> GetUser(string userName, string password)
    {
      return await _db.UserInfos.FirstOrDefaultAsync(u => u.UserName == userName && u.Password == password);
    }
  }
}