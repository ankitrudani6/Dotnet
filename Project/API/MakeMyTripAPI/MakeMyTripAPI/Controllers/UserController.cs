using MakeMyTripAPI.Interfaces;
using MakeMyTripAPI.Models;
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

namespace MakeMyTripAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IConfiguration _config;
        private ILogin LoginService { get; set; }

        public UserController(IConfiguration config, ILogin loginService)
        {
            _config = config;
            LoginService = loginService;
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
                    return RedirectToAction("Get", "Admin");
                }
                return RedirectToAction("Get", "Home");
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
            public IActionResult Registration(LoginInfo loginInfo)
            {
            return Ok(LoginService.Add(loginInfo));
        }

        private string GenerateJSONWebToken(LoginInfo loginInfo)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[] {
                new Claim(JwtRegisteredClaimNames.Email, loginInfo.EmailAddress),
                new Claim(ClaimTypes.Role,loginInfo.IsAdmin.ToString()=="True"?"admin":"user"),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };
            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
              _config["Jwt:Issuer"],
               claims,
              expires: DateTime.Now.AddMinutes(120),
              signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private LoginInfo AuthenticateUser(LoginDTO login)
        {
            LoginInfo user = LoginService.GetAll().Where(u => (u.EmailAddress == login.Username || u.PhoneNumber.ToString() == login.Username) && u.Password == login.Password).FirstOrDefault();

            return user;
        }
    }
}
