using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToyCompanyAPI.Models;

namespace ToyCompanyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToyController : ControllerBase
    {
        private IRepository<Toy> ToyService { get; set; }
        public ToyController(IRepository<Toy> toyService)
        {
            ToyService = toyService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(ToyService.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(ToyService.GetById(id));
        }

        [HttpPost]
        public IActionResult Add(Toy toy)
        {
            return Ok(ToyService.Add(toy));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var toy = ToyService.GetById(id);
            return Ok(ToyService.Delete(toy));
        }

    }
}
