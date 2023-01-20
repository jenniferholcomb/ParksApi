using ParksApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ParksApi.Controllers
{
  public class CallAPIController : Controller
  {
    public IActionResult Index(string message)
    {
      ViewBag.Message = message;
      return View();
    }

    [HttpPost]
    public IActionResult Index(string username, string password)
    {
      if ((username != "secret") || (password != "secret"))
      {
        return View((object)"Login Failed");
      }

      var accessToken = GenerateJSONWebToken();
      SetJWTCookie(accessToken);

      return RedirectToAction("AllParks");
    }

    private string GenerateJSONWebToken()
    {
      var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("MynameisJamesBond007"));
      var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

      var token = new JwtSecurityToken(
            issuer: "https://epicodus.com",
            audience: "https://epicodus.com",
            expires: DateTime.Now.AddHours(3),
            signingCredentials: credentials
            );
      
      return new JwtSecurityTokenHandler().WriteToken(token);
    }

    private void SetJWTCookie(string token)
    {
      var cookieOptions = new CookieOptions {
        HttpOnly = true,
        Expires = DateTime.UtcNow.AddHours(3)
      };
      Response.Cookies.Append("jwtCookie", token, cookieOptions);
    }

    public async Task<IActionResult> AllParks()
    {
      var jwt = Request.Cookies["jwtCookie"];

      using (var httpClient = new HttpClient())
      {
        httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", jwt);
        using (var response = await httpClient.GetAsync("https://localhost:5001/api/Parks"))
        {
          if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
          {
            return RedirectToAction("Index", new { message = "Please Login again"});
          }
        }
      }
      return RedirectToAction("api", new { controller = "Parks"});
    }
  }
}