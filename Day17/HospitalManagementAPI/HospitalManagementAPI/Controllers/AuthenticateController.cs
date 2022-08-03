using HospitalManagementAPI.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementAPI.Controllers
{
    [Route("api/login")]
    [ApiController]
    public class AuthenticateController : ControllerBase
    {
        private readonly IJWTAuthenticationManager jWTAuthenticationManager;

        public AuthenticateController(IJWTAuthenticationManager jWTAuthenticationManager)
        {
            this.jWTAuthenticationManager = jWTAuthenticationManager;
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult Authenticate([FromBody] Login userCred)
        {
            var token = jWTAuthenticationManager.Authenticate(userCred.UserName, userCred.Password);

            if (token == null)
                return Unauthorized();

            return Ok(token);
        }
    }
}
