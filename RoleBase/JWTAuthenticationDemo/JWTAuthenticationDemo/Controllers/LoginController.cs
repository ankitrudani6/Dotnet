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
    public class LoginController : ControllerBase
    {
        private IConfiguration _config;
        private IRepository<UserInfo> UserService { get; set; }

        public LoginController(IConfiguration config, IRepository<UserInfo> userService)
        {
            _config = config;
            UserService = userService;
        }

        [HttpGet]
        [Authorize]
        public ActionResult<IEnumerable<string>> Get()
        {
            var currentUser = HttpContext.User;
            int spendingTimeWithCompany = 0;

            if (currentUser.HasClaim(c => c.Type == "DateOfJoing"))
            {
                DateTime date = DateTime.Parse(currentUser.Claims.FirstOrDefault(c => c.Type == "DateOfJoing").Value);
                spendingTimeWithCompany = DateTime.Today.Year - date.Year;
            }

            if (spendingTimeWithCompany > 5)
            {
                return new string[] { "High Time1", "High Time2", "High Time3", "High Time4", "High Time5" };
            }
            else
            {
                return new string[] { "value1", "value2", "value3", "value4", "value5" };
            }
        }
        [AllowAnonymous]
        [HttpPost]
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

        [HttpPost("registration")]
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
                new Claim(ClaimTypes.Role,userInfo.IsAdmin.ToString()),
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
