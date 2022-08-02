using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToyCompanyAPI.Interfaces;
using ToyCompanyAPI.Models;
using ToyCompanyAPI.Services;

namespace ToyCompanyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private ICustomer CustomerService { get; set; }
        public CustomerController(ICustomer customerService)
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

        [HttpGet("Toys")]
        public IActionResult GetToys()
        {
            return Ok(CustomerService.GetToy());
        }
    }
}
