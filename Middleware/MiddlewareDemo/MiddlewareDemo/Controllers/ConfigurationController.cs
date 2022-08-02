using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MiddlewareDemo.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiddlewareDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConfigurationController : ControllerBase
    {
        private readonly IClientConfiguration clientConfiguration;

        public ConfigurationController(IClientConfiguration clientConfiguration)
        {
            this.clientConfiguration = clientConfiguration;
        }

        [HttpGet]
        public ActionResult<ClientConfiguration> GetConfigurationController()
        {
            return new ClientConfiguration
            {
                ClientName = clientConfiguration.ClientName,
                InvokedDateTime = clientConfiguration.InvokedDateTime
            };
        }
        [HttpGet("cal")]
        public IActionResult Cal()
        {
            var a = 10;
            var b = 0;
            return Ok(a / b);

        }
    }
}
