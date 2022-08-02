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
    public class PersonController : ControllerBase
    {
        private IPerson PersonService { get; set; }
        public PersonController(IPerson personService)
        {
            PersonService = personService;
        }
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(PersonService.GetAll());
        }

        [HttpGet("cal")]
        public IActionResult GetCal()
        {
            var a = 10;
            var b = 0;
            throw new NullReferenceException();
            return Ok("done");
        }
    }
}
