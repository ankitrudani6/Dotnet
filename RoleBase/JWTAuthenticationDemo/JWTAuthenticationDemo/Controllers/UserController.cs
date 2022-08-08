using JWTAuthenticationDemo.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
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

namespace JWTAuthenticationDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IConfiguration _config;
        private IRepository<UserInfo> UserService { get; set; }

        public UserController(IConfiguration config, IRepository<UserInfo> userService)
        {
            _config = config;
            UserService = userService;
        }

        [HttpGet]
        [Authorize]
        public ActionResult Get()
        {
            var currentUser = HttpContext.User;
            if (currentUser.HasClaim(c => c.Type == ClaimTypes.Role))
            {
                var role = currentUser.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role).Value;
                
                if (role == "admin")
                {
                    return RedirectToAction("Get","Admin");
                }
                return RedirectToAction("Get","Home");
            }
            return Unauthorized();  
        }
        [AllowAnonymous]
        [HttpPost]
        [Route("Login")]
        public IActionResult Login([FromBody] LoginDTO login)
        {
            IActionResult response = Unauthorized();
            var user = AuthenticateUser(login);

            if (user != null)
            {
                var tokenString = GenerateJSONWebToken(user);
                response = Ok(new { token = tokenString });
            }

            return response;
        }

        [HttpPost]
        [Route("Registration")]

        public IActionResult Registration(UserInfo userInfo)
        {
            return Ok(UserService.Add(userInfo));
        }

        private string GenerateJSONWebToken(UserInfo userInfo)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[] {
                new Claim(JwtRegisteredClaimNames.Sub, userInfo.FirstName),
                new Claim(JwtRegisteredClaimNames.Email, userInfo.EmailAddress),
                new Claim(ClaimTypes.Role,userInfo.IsAdmin.ToString()=="True"?"admin":"user"),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };
            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
              _config["Jwt:Issuer"],
               claims,
              expires: DateTime.Now.AddMinutes(120),
              signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private UserInfo AuthenticateUser(LoginDTO login)
        {
            UserInfo user = UserService.GetAll().Where(u => (u.EmailAddress == login.Username || u.PhoneNumber.ToString() == login.Username) && u.Password == login.Password).FirstOrDefault();

            return user;
        }

    }
}
