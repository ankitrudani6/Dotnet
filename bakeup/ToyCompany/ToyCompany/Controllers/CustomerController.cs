using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToyCompany.Models;
using ToyCompany.Services;

namespace ToyCompany.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private ICustomerService CustomerService { get; set; }
        public CustomerController(ICustomerService customerService)
        {
            CustomerService = customerService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(CustomerService.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(CustomerService.GetById(id));
        }

        [HttpPost]
        public IActionResult Post(Customer customer)
        {
            return Ok(CustomerService.Add(customer));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var customer = CustomerService.GetById(id);
            return Ok(CustomerService.Delete(customer));
        }
    }
}
