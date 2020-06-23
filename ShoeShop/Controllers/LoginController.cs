using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        public IConfiguration Configuration { get; }
        public LoginController(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        //[AllowAnonymous]
        //[HttpPost]
        //public IActionResult RequestToken()
        //{
        //    var claims = new[] { new Claim(ClaimTypes.Name, "Fuad") };

        //    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("LKSJDFKL"));
        //    var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        //    var token = new JwtSecurityToken(
        //        issuer: "yourdomain.com",
        //        audience: "yourdomain.com",
        //        claims: claims,
        //        expires: DateTime.Now.AddMinutes(30),
        //        signingCredentials: creds);

        //    return Ok(new
        //    {
        //        token = new JwtSecurityTokenHandler().WriteToken(token)
        //    });
        //}


        // GET: api/Products
        [HttpGet("RequestToken")]
        public ActionResult RequestToken()
        {
            var claims = new[] { new Claim(ClaimTypes.Name, "Fuad") };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("LKSJDFKLLKSJDFKLLKSJDFKL"));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: "yourdomain.com",
                audience: "yourdomain.com",
                claims: claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: creds);

            return Ok(new
            {
                token = new JwtSecurityTokenHandler().WriteToken(token)
            });
            //var result = await _productsRepository.GetProducts();
            //return Ok(result);
        }
    }
}
