using AdvanceLINQPractice.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdvanceLINQPractice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QueryController : ControllerBase
    {
        private makemytrip2435ankitContext context { get; set; }
        public QueryController(makemytrip2435ankitContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var result = "Hello";
            return Ok(result);
        }
    }
}
