using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using HseApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Security.Cryptography;
using Newtonsoft.Json;
namespace HseApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {


        private IConfiguration _config;
        private readonly hse_dev_2019Context _context;

        public AuthController(IConfiguration config, hse_dev_2019Context context)
        {
            _config = config;
            _context = context;

        }
        static string Hash(string input)
        {
            using (SHA1Managed sha1 = new SHA1Managed())
            {
                var hash = sha1.ComputeHash(Encoding.UTF8.GetBytes(input));
                var sb = new StringBuilder(hash.Length * 2);

                foreach (byte b in hash)
                {
                    // can be "x2" if you want lowercase
                    sb.Append(b.ToString("X2"));
                }

                return sb.ToString().ToLower();
            }
        }

        //[AllowAnonymous]
        //[HttpPost]
        ////[Route("Login")]
        //public IActionResult Login([FromBody]CoreUser login)
        //{
        //    IActionResult response = Unauthorized();
        //    var user = AuthenticateUser(login);

        //    if (user != null)
        //    {
        //        var tokenString = GenerateJSONWebToken(user);
        //        response = Ok(new { token = tokenString });
        //    }

        //    return response;
        //}
        //private CoreUser AuthenticateUser(CoreUser login)
        //{
           
        //    var password_mobile = Hash(login.PasswordMobile);
        //    var query = _context.CoreUser
        //                           .Where(s => s.Username == login.Username && s.PasswordMobile == password_mobile)
        //                           .FirstOrDefault<CoreUser>();

        //    //var password_mobile2 = Hash("123");
        //    //var query2 = _context.CoreUser
        //    //           .Where(s => s.Username == "nguyenhuuthanh" && s.PasswordMobile == password_mobile2)
        //    //           .FirstOrDefault<CoreUser>();
            
        //    return query;
        //}
        //private string GenerateJSONWebToken(CoreUser userInfo)
        //{
        //    var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
        //    var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        //    var token = new JwtSecurityToken(_config["Jwt:Issuer"],
        //      _config["Jwt:Issuer"],
        //      null,
        //      expires: DateTime.Now.AddMinutes(120),
        //      signingCredentials: credentials);

        //    return new JwtSecurityTokenHandler().WriteToken(token);
        //}

        [HttpPost]
        [Route("Login")]
        public ActionResult GetToken([FromBody]CoreUser login)
        {
            try
            {
                var password_mobile = Hash(login.PasswordMobile);
                var query = _context.CoreUser
                                       .Where(s => s.Username == login.Username && s.PasswordMobile == password_mobile)
                                       .FirstOrDefault<CoreUser>();
                if (query != null)
                {
                    //symmetric security key
                    var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));

                    //signing credentials
                    var singingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);
                    // add claims
                    dynamic json = JsonConvert.DeserializeObject(query.Data);
                    var claims = new List<Claim>();
                    claims.Add(new Claim(ClaimTypes.Role, query.Username));
                    claims.Add(new Claim(ClaimTypes.Role, "Custom_claim1", "Custom value1"));
                    claims.Add(new Claim(JwtRegisteredClaimNames.Email, query.Email));
                    claims.Add(new Claim(JwtRegisteredClaimNames.Sub, query.Data));
                    //create token
                    var token = new JwtSecurityToken(_config["Jwt:Issuer"],
                      _config["Jwt:Issuer"],
                      claims,
                      expires: DateTime.Now.AddMinutes(120),
                      signingCredentials: singingCredentials);

                    //return token
                    return Ok(new JwtSecurityTokenHandler().WriteToken(token));
                }
                else
                {
                    //return token
                    return Unauthorized();
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}