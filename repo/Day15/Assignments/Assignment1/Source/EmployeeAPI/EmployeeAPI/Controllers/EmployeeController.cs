using EmployeeAPI.Interfaces;
using EmployeeAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeAPI.Controllers
{
    [Route("api/emps")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private IEmployee EmployeeService { get; set; }
        public EmployeeController(IEmployee employeeService)
        {
            EmployeeService = employeeService;
        }
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(EmployeeService.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(EmployeeService.GetById(id));
        }

        [HttpPost]
        public IActionResult Add(Employee employee)
        {
            return Ok(EmployeeService.Add(employee));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var employee = EmployeeService.GetById(id);
            return Ok(EmployeeService.Delete(employee));
        }
        [HttpPut("{id}")]
        public IActionResult Put(int id, Employee newEmployee)
        {
            var employee = EmployeeService.GetById(id);
            return Ok(EmployeeService.Put(employee, newEmployee));
        }
    }
}
