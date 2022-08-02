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
    [Route("api/emps/[controller]")]
    [ApiController]
    public class AssignmentController : ControllerBase
    {
        private IAssignment AssignmentService { get; set; }
        public AssignmentController(IAssignment assignmentService)
        {
            AssignmentService = assignmentService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(AssignmentService.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(AssignmentService.GetById(id));
        }

        [HttpPost]
        public IActionResult Add(Assignment assignment)
        {
            return Ok(AssignmentService.Add(assignment));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var assignment = AssignmentService.GetById(id);
            return Ok(AssignmentService.Delete(assignment));
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id,Assignment newAssignment)
        {
            var assignment = AssignmentService.GetById(id);
            return Ok(AssignmentService.Put(assignment, newAssignment));
        }

    }
}
